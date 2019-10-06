using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BPageContent
    {
        public BPageContent()
        {
            BContent = new HashSet<BContent>();
        }

        public int PageContentId { get; set; }
        public string PageContentTitle { get; set; }

        public virtual ICollection<BContent> BContent { get; set; }
    }
}
