using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BPicture
    {
        public int PictureId { get; set; }
        public int MemberId { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? DateUploaded { get; set; }
        public byte[] DocumentPhoto { get; set; }
        public DateTime? DocumentUploadedDate { get; set; }
    }
}
