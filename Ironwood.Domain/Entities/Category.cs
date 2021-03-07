using System;
using System.Collections;
using System.Collections.Generic;

namespace Ironwood.Domain.Entities
{
    public class Category
    {
        public Guid UID { get; set; }
        
        public string Name { get; set; }
        public string Details { get; set; }

        public ICollection<Match> Matches  { get; private set; } = new HashSet<Match>();
       
    }
}