using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Wallets.Queries
{
    public class GetWalletHistoryQuery : IRequest<IEnumerable<WalletTransaction>>
    {
        public Guid WalletAddress { get; set; }
        public class GetWalletHistoryQueryHandler : IRequestHandler<GetWalletHistoryQuery, IEnumerable<WalletTransaction>>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;

            public GetWalletHistoryQueryHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }
            public async Task<IEnumerable<WalletTransaction>> Handle(GetWalletHistoryQuery request, CancellationToken cancellationToken)
            {
               var _walletHistory = await dbContext.Wallets
               .Include(a => a.WalletTransactions)
               .SingleOrDefaultAsync(a => a.Address == request.WalletAddress);

               return _walletHistory.WalletTransactions;

            }
        }
    }
}