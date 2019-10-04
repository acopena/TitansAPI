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
            BClinic = new HashSet<BClinic>();
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

        public BAssociationProfile BAssociationProfile { get; set; }
        public ICollection<BAssociationAddress> BAssociationAddress { get; set; }
        public ICollection<BAssociationBank> BAssociationBank { get; set; }
        public ICollection<BAssociationContactInfo> BAssociationContactInfo { get; set; }
        public ICollection<BClinic> BClinic { get; set; }
        public ICollection<BDiscountFees> BDiscountFees { get; set; }
        public ICollection<BEvents> BEvents { get; set; }
        public ICollection<BFeeTrx> BFeeTrx { get; set; }
        public ICollection<BMember> BMember { get; set; }
        public ICollection<BSiteApprover> BSiteApprover { get; set; }
        public ICollection<BUsers> BUsers { get; set; }
    }
}
