using System;
using Ironwood.Application.ViewModels;
using Ironwood.Application.Vouchers.Commands;


namespace Ironwood.UI.Models
{
    public class WalletVM
    {
        public string UserEmail { get; set; }
        public Guid UID { get; set; }
        public decimal Balance { get; set; }
       public WalletHistoryVM WalletHistory { get; set; }
        public RedeemVoucherCommand VoucherCommand { get; set; }

    }
}
