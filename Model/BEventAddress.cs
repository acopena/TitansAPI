using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BEventAddress
    {
        public int EventAddressId { get; set; }
        public int EventNo { get; set; }
        public string EventStreetNo { get; set; }
        public string EventStreetName { get; set; }
        public string EventStreetType { get; set; }
        public string EventCity { get; set; }
        public string EventProvince { get; set; }
        public string EventPostalCode { get; set; }
        public string LocationDesc { get; set; }

        public virtual BEvents EventNoNavigation { get; set; }
    }
}
