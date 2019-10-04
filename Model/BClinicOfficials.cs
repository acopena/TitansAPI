using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicOfficials
    {
        public int ClinicOfficialId { get; set; }
        public int ClinicId { get; set; }
        public int OfficialId { get; set; }
        public int PositionId { get; set; }

        public BClinic Clinic { get; set; }
        public BOfficial Official { get; set; }
        public BPosition Position { get; set; }
    }
}
