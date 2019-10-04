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

        public BCartStatus CartStatus { get; set; }
        public BUsers User { get; set; }
        public ICollection<BMemberDiscount> BMemberDiscount { get; set; }
        public ICollection<BMemberFees> BMemberFees { get; set; }
        public ICollection<BMemberRegistration> BMemberRegistration { get; set; }
        public ICollection<BMemberServiceFee> BMemberServiceFee { get; set; }
        public ICollection<BReceipt> BReceipt { get; set; }
    }
}
