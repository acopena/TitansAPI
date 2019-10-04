using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicProgramTrx
    {
        public int ClinicProgramTrxId { get; set; }
        public int ClinicProgramId { get; set; }
        public int ClinicId { get; set; }

        public BClinic Clinic { get; set; }
        public BClinicPrograms ClinicProgram { get; set; }
    }
}
