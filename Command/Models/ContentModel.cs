using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Command.Models
{
    public class ContentModel
    {

        public int ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDetails { get; set; }
        public DateTime? PublishedEndDate { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? DateModified { get; set; }
        public int? PageContentId { get; set; }
        public string PageContentTitle { get; set; }
        public bool? IsExpired { get; set; }
        public int? ContentTypeId { get; set; }
        public string ContentTypeDesc { get; set; }
        public DateTime? PublishedStartDate { get; set; }
        public int? SortKey { get; set; }
    }

    public class ContentParamModel
    {
        public int ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDetails { get; set; }
        public int UserId { get; set; }

        public int PublishStartYear { get; set; }
        public int PublishStartMonth { get; set; }
        public int PublishStartDay { get; set; }

        public int PublishedEndYear { get; set; }
        public int PublishedEndMonth { get; set; }
        public int PublishedEndDay { get; set; }

        public int ContentTypeId { get; set; }
        public int PageContentId { get; set; }
    }
}

