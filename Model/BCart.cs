using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BCart
    {
        public BCart()
        {
            BMemberDiscount = new HashSet<BMemberDiscount>();
            BMemberFees = new HashSet<BMemberFees>();
            BMemberRegistration = new HashSet<BMemberRegistration>();
            BMemberServiceFee = new HashSet<BMemberServiceFee>();
            BReceipt = new HashSet<BReceipt>();
        }

        public Guid CartGuid { get; set; }
        public DateTime CartDate { get; set; }
        public int CartStatusId { get; set; }
        public int UserId { get; set; }
        public int? SeasonId { get; set; }
        public int? AssociationId { get; set; }

        public virtual BCartStatus CartStatus { get; set; }
        public virtual BUsers User { get; set; }
        public virtual ICollection<BMemberDiscount> BMemberDiscount { get; set; }
        public virtual ICollection<BMemberFees> BMemberFees { get; set; }
        public virtual ICollection<BMemberRegistration> BMemberRegistration { get; set; }
        public virtual ICollection<BMemberServiceFee> BMemberServiceFee { get; set; }
        public virtual ICollection<BReceipt> BReceipt { get; set; }
    }
}
