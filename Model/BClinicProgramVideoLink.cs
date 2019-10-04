using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicProgramVideoLink
    {
        public int ClinicProgramVideoLinkId { get; set; }
        public int ClinicProgramId { get; set; }
        public string ClinicProgramVideoName { get; set; }
        public DateTime? ClinicProgramUploadedDate { get; set; }
        public int? ClinicProgramUploadedById { get; set; }
        public int? AssociationId { get; set; }
        public string ClinicProgramData { get; set; }

        public BClinicPrograms ClinicProgram { get; set; }
    }
}
