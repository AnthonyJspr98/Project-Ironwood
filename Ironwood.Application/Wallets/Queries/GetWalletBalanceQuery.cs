using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Wallets.Queries
{    
    public class GetWalletBalanceQuery : IRequest<decimal>
    {
        public Guid WalletAddress { get; set; }

        public class GetWalletBalanceQueryHandler : IRequestHandler<GetWalletBalanceQuery, decimal>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;
            public GetWalletBalanceQueryHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }

            public async Task<decimal> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
            {
                var _wallet = await dbContext.Wallets
                .Include(a => a.WalletTransactions)
                .SingleOrDefaultAsync(a => a.Address == request.WalletAddress);

                var _walletBalance = _wallet.WalletTransactions.Sum(a => a.Amount);
               
               return _walletBalance;
                
            }
        }
    }
}