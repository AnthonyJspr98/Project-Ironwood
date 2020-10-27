using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwood.Application.UserLogins.Queries
{
    public class FindLoginQuery : IRequest<UserLogin>
    {
        #region Public members
        public string EmailAddress { get; set; }
        #endregion

        #region Handler
        public class FindLoginQueryHandler : IRequestHandler<FindLoginQuery, UserLogin>
        {
            private readonly IMediator mediator;
            private readonly IIronwoodDbContext dbContext;

            public FindLoginQueryHandler(IMediator mediator, IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }

            public async Task<UserLogin> Handle(FindLoginQuery request, CancellationToken cancellationToken)
            {
                var _user = await dbContext.Users
                     .Include(a => a.UserLogin)
                     .Include(a => a.Wallet)
                     .SingleOrDefaultAsync(a => a.UserLogin.Username == request.EmailAddress
                     || a.EmailAddress == request.EmailAddress);

                if (_user == null)
                {
                    return null;
                }

                return _user.UserLogin;
            }
        }
        #endregion
    }
}
