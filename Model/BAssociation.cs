using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BAssociation
    {
        public BAssociation()
        {
            BAssociationAddress = new HashSet<BAssociationAddress>();
            BAssociationBank = new HashSet<BAssociationBank>();
            BAssociationContactInfo = new HashSet<BAssociationContactInfo>();
            BDiscountFees = new HashSet<BDiscountFees>();
            BEvents = new HashSet<BEvents>();
            BFeeTrx = new HashSet<BFeeTrx>();
            BMember = new HashSet<BMember>();
            BSiteApprover = new HashSet<BSiteApprover>();
            BUsers = new HashSet<BUsers>();
        }

        public int AssociationId { get; set; }
        public string AssociationName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public byte[] AssociationLogo { get; set; }
        public string AssociationShortName { get; set; }

        public virtual BAssociationProfile BAssociationProfile { get; set; }
        public virtual ICollection<BAssociationAddress> BAssociationAddress { get; set; }
        public virtual ICollection<BAssociationBank> BAssociationBank { get; set; }
        public virtual ICollection<BAssociationContactInfo> BAssociationContactInfo { get; set; }
        public virtual ICollection<BDiscountFees> BDiscountFees { get; set; }
        public virtual ICollection<BEvents> BEvents { get; set; }
        public virtual ICollection<BFeeTrx> BFeeTrx { get; set; }
        public virtual ICollection<BMember> BMember { get; set; }
        public virtual ICollection<BSiteApprover> BSiteApprover { get; set; }
        public virtual ICollection<BUsers> BUsers { get; set; }
    }
}
