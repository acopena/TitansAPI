using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BContentApproved
    {
        public int SiteContentApprovedId { get; set; }
        public int ContentId { get; set; }
        public int? AppprovedId { get; set; }
        public DateTime? DateApproved { get; set; }

        public virtual BSiteApprover Appproved { get; set; }
        public virtual BContent Content { get; set; }
    }
}
