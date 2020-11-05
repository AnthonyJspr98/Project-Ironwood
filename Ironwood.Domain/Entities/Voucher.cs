using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Domain.Entities
{
    public class Voucher
    {
        public Guid UID { get; set; }
        public string Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public decimal Value { get; set; }
        public bool IsRedeemed { get; set; }


        public ICollection<VoucherTransaction> VoucherTransactions { get; private set; } = new HashSet<VoucherTransaction>();

    }
}
