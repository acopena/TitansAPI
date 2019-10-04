using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BSponsors
    {
        public int SponsorsId { get; set; }
        public string SponsorsName { get; set; }
        public string SponsorsImageUrl { get; set; }
        public string SponsorsNavigateUrl { get; set; }
        public DateTime? SponsorsDateCreated { get; set; }
    }
}
