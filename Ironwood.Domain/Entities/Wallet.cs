using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Domain.Entities
{
    public class Wallet
    {
        public Guid Address { get; set; }

        public User User { get; set; }
        public ICollection<WalletTransaction> WalletTransactions { get; private set; } = new HashSet<WalletTransaction>();
    }
}
