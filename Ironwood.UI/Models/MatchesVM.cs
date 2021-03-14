using System.Collections.Generic;
using Ironwood.Domain.Entities;

namespace Ironwood.UI.Models
{
    public class MatchesVM
    {
        public IEnumerable<Match> DotaMatches { get; set; }
    }
}