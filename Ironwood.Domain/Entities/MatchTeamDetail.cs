using System;
using System.Collections;
using System.Collections.Generic;

namespace Ironwood.Domain.Entities
{
    public class MatchTeamDetail
    {
        public Guid UID { get; set; }

        public Match Match { get; set; }
        public Team Team { get; set; }
        public bool IsWon { get; set; }
       
    }
}