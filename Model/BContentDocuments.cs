using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BContentDocuments
    {
        public int DocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public DateTime? DateUploaded { get; set; }
        public int? ContentId { get; set; }
        public string DocumentFileName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNotes { get; set; }

        public virtual BContent Content { get; set; }
    }
}
