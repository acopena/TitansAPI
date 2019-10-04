using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicProgramAttachment
    {
        public int ProgramAttachmentId { get; set; }
        public int ClinicProgramId { get; set; }
        public byte[] ProgramData { get; set; }
        public string ProgramDataName { get; set; }
        public long? ProgramDataSize { get; set; }
        public DateTime? ProgramDateUploaded { get; set; }
        public int? ProgramUploadedBy { get; set; }
        public int? AssociationId { get; set; }

        public BClinicPrograms ClinicProgram { get; set; }
    }
}
