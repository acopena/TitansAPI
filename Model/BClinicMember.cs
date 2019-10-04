using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicMember
    {
        public int ClinicMemberId { get; set; }
        public int ClinicId { get; set; }
        public int MemberId { get; set; }

        public BClinic Clinic { get; set; }
        public BMember Member { get; set; }
    }
}
