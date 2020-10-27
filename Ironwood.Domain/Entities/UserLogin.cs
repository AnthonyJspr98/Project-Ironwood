using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Domain.Entities
{
    public class UserLogin
    {
        public string Username { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }
        public DateTime LastChangedPassword { get; set; }

        public User User { get; set; }
        public ICollection<LoginHistory> LoginHistory { get; private set; } = new HashSet<LoginHistory>();
    }
}
