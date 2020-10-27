using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Domain.Entities
{
    public class LoginHistory
    {
        public string IP { get; set; }
        public DateTime LoggedOn { get; set; }

        public string CountryCode { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
    }
}
