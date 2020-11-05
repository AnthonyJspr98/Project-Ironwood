using FluentValidation;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Application.Common.Interfaces.Security;
using Ironwood.Domain.Entities;
using Ironwood.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwood.Application.Users.Commands
{
    public class RegisterCommand : IRequest<User>
    {
        #region Public Members
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }      
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        #endregion

        #region Handler
        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, User>
        {
            private readonly IMediator mediator;
            private readonly IIronwoodDbContext dbContext;
            private readonly IPasswordHasher passwordHasher;

            public RegisterCommandHandler(IMediator mediator, IIronwoodDbContext dbContext, IPasswordHasher passwordHasher)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
                this.passwordHasher = passwordHasher;
            }

            public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] _salt = passwordHasher.GenerateSalt();
                byte[] _passHash = passwordHasher.HashPassword(_salt, request.Password);

                User _user = new User
                {
                    UID = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    AccessRole = AccessRole.DefaultUser,
                    EmailAddress = request.EmailAddress,                   
                    UserLogin = new UserLogin
                    {
                        Username = request.EmailAddress,
                        Salt = _salt,
                        Password = _passHash
                    },
                    Wallet = new Wallet
                    {
                        Address = Guid.NewGuid()
                    }
                };

                dbContext.Users.Add(_user);

                return _user;

            }
        }
        #endregion

        #region Validator
        public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
        {
            public RegisterCommandValidator()
            {
                RuleFor(a => a.FirstName).NotNull().MaximumLength(100).WithMessage("Required");
                RuleFor(a => a.MiddleName).MaximumLength(100);
                RuleFor(a => a.LastName).NotNull().MaximumLength(100);
                RuleFor(a => a.EmailAddress).NotNull().MaximumLength(320);               
                RuleFor(a => a.Password).NotNull()
                    .MaximumLength(100)
                    .MinimumLength(6);
                RuleFor(a => a.ConfirmPassword).NotNull().Equal(a => a.Password).MaximumLength(100);
            }
        }
        #endregion
    }
}
