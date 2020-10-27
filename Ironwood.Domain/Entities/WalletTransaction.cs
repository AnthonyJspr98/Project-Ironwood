using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Domain.Entities
{
    public class WalletTransaction
    {
        public Guid UID { get; set; }
        public DateTime TransactedOn { get; set; }
        public Decimal Amount { get; set; }
        public string Remarks { get; set; }

        public Wallet Wallet { get; set; }
    }
}
