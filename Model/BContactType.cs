using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BContactType
    {
        public BContactType()
        {
            BAssociationContactInfo = new HashSet<BAssociationContactInfo>();
            BMemberContactInfo = new HashSet<BMemberContactInfo>();
        }

        public int ContactTypeId { get; set; }
        public string ContactTypeDesc { get; set; }
        public int? ContactGroupId { get; set; }
        public int? SortOrder { get; set; }

        public virtual ICollection<BAssociationContactInfo> BAssociationContactInfo { get; set; }
        public virtual ICollection<BMemberContactInfo> BMemberContactInfo { get; set; }
    }
}
