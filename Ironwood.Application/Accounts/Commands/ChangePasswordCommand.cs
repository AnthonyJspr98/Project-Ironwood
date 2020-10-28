using Ironwood.Application.Common.Interfaces;
using Ironwood.Application.Common.Interfaces.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwood.Application.Accounts.Commands
{
    public class ChangePasswordCommand : IRequest
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string CurrentPassword { get; set; }

        public class ChangePasswordCommandHandler : AsyncRequestHandler<ChangePasswordCommand>
        {
            private readonly IMediator mediator;
            private readonly IIronwoodDbContext dbContext;
            private readonly ICurrentUser currentUser;
            private readonly IPasswordHasher passwordHasher;

            public ChangePasswordCommandHandler(IMediator mediator, IIronwoodDbContext dbContext, ICurrentUser currentUser, IPasswordHasher passwordHasher)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
                this.currentUser = currentUser;
                this.passwordHasher = passwordHasher;
                
            }

            protected override async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                var _user = await dbContext.Users
                    .Include(a => a.UserLogin)
                    .SingleOrDefaultAsync(a => a.UID == currentUser.UID);

                if (request.NewPassword == request.ConfirmNewPassword)
                {
                    if (passwordHasher.IsPasswordVerified(_user.UserLogin.Salt, _user.UserLogin.Password, request.CurrentPassword))
                    {
                        _user.UserLogin.Password = passwordHasher.HashPassword(_user.UserLogin.Salt, request.NewPassword);
                    }
                    else
                    {
                        throw new Exception("Current Password Incorrect");
                    }
                }
                else
                {
                    throw new Exception("New Password did not Match");
                }
            }
        }
    }
}
