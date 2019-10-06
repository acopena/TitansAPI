using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BSiteApprover
    {
        public BSiteApprover()
        {
            BContentApproved = new HashSet<BContentApproved>();
        }

        public int ApprovedId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool? Active { get; set; }
        public int AssociationId { get; set; }
        public int SeasonId { get; set; }

        public virtual BAssociation Association { get; set; }
        public virtual BSeason Season { get; set; }
        public virtual ICollection<BContentApproved> BContentApproved { get; set; }
    }
}
