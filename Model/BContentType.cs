using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BContentType
    {
        public BContentType()
        {
            BContent = new HashSet<BContent>();
        }

        public int ContentTypeId { get; set; }
        public string ContentTypeName { get; set; }
        public int? ContentSortKey { get; set; }

        public virtual ICollection<BContent> BContent { get; set; }
    }
}
