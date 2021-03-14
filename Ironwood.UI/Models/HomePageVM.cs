using System.Collections.Generic;
using Ironwood.Domain.Entities;

namespace Ironwood.UI.Models
{
    public class HomePageVM
    {
        public IEnumerable<Match> IncomingMatch { get; set; }
        public IEnumerable<Match> IncomingDotaMatches { get; set; }
             
    }
}