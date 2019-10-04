using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicPrograms
    {
        public BClinicPrograms()
        {
            BClinicProgramAttachment = new HashSet<BClinicProgramAttachment>();
            BClinicProgramTrx = new HashSet<BClinicProgramTrx>();
            BClinicProgramVideoLink = new HashSet<BClinicProgramVideoLink>();
            BTeamProgram = new HashSet<BTeamProgram>();
        }

        public int ClinicProgramId { get; set; }
        public string ClinicProgramName { get; set; }
        public int? ClinicProgramTypeId { get; set; }

        public BClinicProgramType ClinicProgramType { get; set; }
        public ICollection<BClinicProgramAttachment> BClinicProgramAttachment { get; set; }
        public ICollection<BClinicProgramTrx> BClinicProgramTrx { get; set; }
        public ICollection<BClinicProgramVideoLink> BClinicProgramVideoLink { get; set; }
        public ICollection<BTeamProgram> BTeamProgram { get; set; }
    }
}
