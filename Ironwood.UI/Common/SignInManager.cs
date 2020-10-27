using Ironwood.Application.Common.Interfaces;
using Ironwood.Application.Common.Interfaces.Security;
using Ironwood.Application.LoginHistories.Commands;
using Ironwood.Application.UserLogins.Queries;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ironwood.UI.Common
{
    public class SignInManager : ISignInManager
    {
        private readonly IMediator mediator;
        private readonly IJsonSerializer jsonSerializer;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ILogger logger;
        private readonly IPasswordHasher passwordHasher;
        private readonly DbContext writeOnlyDbContext;

        public SignInManager(
            IMediator mediator, IJsonSerializer jsonSerializer,
            IHttpContextAccessor contextAccessor,
            ILogger<SignInManager> logger,
            IPasswordHasher passwordHasher,           
            DbContext writeOnlyDbContext)
        {
            this.mediator = mediator;
            this.jsonSerializer = jsonSerializer;
            this.contextAccessor = contextAccessor;
            this.logger = logger;
            this.passwordHasher = passwordHasher;
            this.writeOnlyDbContext = writeOnlyDbContext;
        }
        public Task ImpersonateAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task PasswordSignInAsync(string usernameOrEmail, string password)
        {
            var _userLogin = await mediator.Send(new FindLoginQuery { EmailAddress = usernameOrEmail});

            if (_userLogin == null)
            {
                throw new Exception("Invalid username or password");
            }

            if (_userLogin.User == null)
            {
                throw new Exception("User is not define");
            }

            if (!passwordHasher.IsPasswordVerified(_userLogin.Salt, _userLogin.Password, password))
            {
                throw new Exception("Invalid username or password");
            }

            await signIn(_userLogin.User);

            string _ip = contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            await mediator.Send(new LogLoginHistoryCommand { Login = _userLogin, IP = _ip });

            await writeOnlyDbContext.SaveChangesAsync();
        }

        private async Task signIn(User user)
        {
            string _userData = jsonSerializer.Serialize(user);
            Guid _sessionUID = Guid.NewGuid();

            var _claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UID.ToString(), ClaimValueTypes.String),
                    new Claim(ClaimTypes.Name, user.FirstName, ClaimValueTypes.String),
                    new Claim(ClaimTypes.Sid, _sessionUID.ToString(), ClaimValueTypes.String),
                    new Claim(ClaimTypes.UserData, _userData, ClaimValueTypes.String)
                };

           
                _claims.Add(new Claim(ClaimTypes.Role, user.AccessRole.ToString(), ClaimValueTypes.String));
            

            var _identity = new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var _principal = new ClaimsPrincipal(_identity);

            await contextAccessor.HttpContext.SignInAsync(_principal);
    
        }

        public Task SignInAsync(string usernameOrEmail)
        {
            throw new NotImplementedException();
        }

        public async Task SignOutAsync()
        {
            await contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        }

        public Task SignOutImpersonateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
