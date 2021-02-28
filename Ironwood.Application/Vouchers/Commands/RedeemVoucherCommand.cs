using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using Ironwood.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Vouchers.Commands
{
    public class RedeemVoucherCommand : IRequest<Voucher>
    {
        public string VoucherCode { get; set; }
        public class RedeemVoucherCommandHandler : IRequestHandler<RedeemVoucherCommand, Voucher>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;
            public RedeemVoucherCommandHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }
            public async Task<Voucher> Handle(RedeemVoucherCommand request, CancellationToken cancellationToken)
            {
                var _voucher =  dbContext.Vouchers
                .Include(a => a.VoucherTransactions)
                .SingleOrDefault(a => a.Code == request.VoucherCode);

                if (_voucher != null)
                {
                    if (_voucher.IsRedeemed)
                {
                     throw new Exception("Voucher Already Redeemed");
                }
                else
                {
                    var _user =  await dbContext.Users
                    .Include(a => a.Wallet)
                    .SingleOrDefaultAsync(a => a.UID == currentUser.UID);
                                       
                    var _walletTransaction = new WalletTransaction
                    {
                        UID = Guid.NewGuid(),
                        TransactedOn = DateTime.Now,
                        Amount = +_voucher.Value,
                        TransactionType = TransactionType.CashIn,
                        Remarks = "Voucher Cash In"                       
                    };
                    var _voucherTransaction = new VoucherTransaction
                    {
                        RedeemedOn = DateTime.Now,
                        Wallet = _user.Wallet,
                        Voucher = _voucher
                    };

                    _user.Wallet.WalletTransactions.Add(_walletTransaction);
                    _voucher.VoucherTransactions.Add(_voucherTransaction);
                    _voucher.IsRedeemed = true;
                
                    return _voucher;
                }
                }
                else
                {
                    throw new Exception("Voucher doesnt exist");

                }   
            }
        }
        
    }
}