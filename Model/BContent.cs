using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BContent
    {
        public BContent()
        {
            BContentApproved = new HashSet<BContentApproved>();
            BContentDocuments = new HashSet<BContentDocuments>();
        }

        public int ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDetails { get; set; }
        public DateTime? PublishedEndDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateModified { get; set; }
        public int? PageContentId { get; set; }
        public bool? IsExpired { get; set; }
        public int? ContentTypeId { get; set; }
        public DateTime? PublishedStartDate { get; set; }
        public int? SortKey { get; set; }

        public BContentType ContentType { get; set; }
        public BPageContent PageContent { get; set; }
        public ICollection<BContentApproved> BContentApproved { get; set; }
        public ICollection<BContentDocuments> BContentDocuments { get; set; }
    }
}
