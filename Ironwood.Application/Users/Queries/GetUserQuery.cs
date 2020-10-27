using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwood.Application.Users.Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public Guid UID;

        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
        {
            private readonly IMediator mediator;
            private readonly IIronwoodDbContext dbContext;

            public GetUserQueryHandler(IMediator mediator, IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }
            public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var _userData = await dbContext.Users
                    .Include(a => a.UserLogin)
                    .Include(a => a.Wallet)
                    .SingleOrDefaultAsync(a => a.UID == request.UID);

                return _userData;
                    
            }
        }
    }
}
