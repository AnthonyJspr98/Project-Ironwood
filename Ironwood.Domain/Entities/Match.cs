using System;
using System.Collections.Generic;
using Ironwood.Enums;

namespace Ironwood.Domain.Entities
{
    public class Match
    {
        public Guid UID { get; set; }

        public MatchStatus Status { get; set; }      
        public DateTime MatchDateandTime { get; set; }
        public MatchCategory MatchCategory { get; set; }
        public Tournament Tournament { get; set; }    
           
        public ICollection<MatchTeamDetail> MatchTeamDetails { get; private set; } = new HashSet<MatchTeamDetail>();
        public ICollection<Bet> Bets { get; private set; } = new HashSet<Bet>();
    }
}