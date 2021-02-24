using System;
using System.Collections;
using System.Collections.Generic;
using Ironwood.Application.Vouchers.Commands;
using Ironwood.Domain.Entities;

namespace Ironwood.UI.Models
{
    public class WalletVM
    {
        public string UserEmail { get; set; }
        public Guid UID { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<WalletTransaction> WalletHistory { get; set; }
        public RedeemVoucherCommand VoucherCommand { get; set; }

    }
}
