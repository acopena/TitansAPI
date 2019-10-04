using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicProgramType
    {
        public BClinicProgramType()
        {
            BClinicPrograms = new HashSet<BClinicPrograms>();
        }

        public int ClinicProgramTypeId { get; set; }
        public string ClinicProgramTypeName { get; set; }

        public ICollection<BClinicPrograms> BClinicPrograms { get; set; }
    }
}
