using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BPosition
    {
        public BPosition()
        {
            BClinicOfficials = new HashSet<BClinicOfficials>();
            BClinicstaff = new HashSet<BClinicstaff>();
            BOfficial = new HashSet<BOfficial>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int? PositionTypeId { get; set; }

        public BPositionType PositionType { get; set; }
        public ICollection<BClinicOfficials> BClinicOfficials { get; set; }
        public ICollection<BClinicstaff> BClinicstaff { get; set; }
        public ICollection<BOfficial> BOfficial { get; set; }
    }
}
