using System;
using Ironwood.Enums;

namespace Ironwood.Domain.Entities
{
    public class Bet
    {
        public Guid UID { get; set; }
        
        public Match Match { get; set; }
        public BetStatus BetStatus { get; set; }
        public decimal Amount { get; set; }
        public Wallet Wallet { get; set; }
        public Team Team { get; set; }
       
    }
}