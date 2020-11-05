
using Ironwood.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Domain.Entities
{
    public class User
    {      
        public Guid UID { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }    
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public AccessRole AccessRole { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public UserLogin UserLogin { get; set; }
        public Wallet Wallet { get; set; }
        

    }
}
    