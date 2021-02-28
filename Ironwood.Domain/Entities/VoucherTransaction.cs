using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Domain.Entities
{
    public class VoucherTransaction
    {
        public Wallet Wallet { get; set; }
        public Voucher Voucher { get; set; }
        public DateTime RedeemedOn { get; set; }
    }
}
