using System;
using System.Collections.Generic;

namespace Ironwood.Domain.Entities
{
    public class Team
    {
        public Guid UID { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<MatchTeamDetail> MatchTeamDetails { get; private set; } = new HashSet<MatchTeamDetail>();
        public ICollection<Bet> Bets {get; private set;} = new HashSet<Bet>();
    }
}