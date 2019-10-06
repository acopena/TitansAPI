using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BDiscountFees
    {
        public BDiscountFees()
        {
            BMemberDiscount = new HashSet<BMemberDiscount>();
        }

        public int DiscountFeeId { get; set; }
        public string DiscountFeeName { get; set; }
        public int SeasonId { get; set; }
        public int AssociationId { get; set; }
        public int? DiscountFeeQty { get; set; }
        public decimal? DiscountFeeAmount { get; set; }
        public int DiscountFeeTypeId { get; set; }

        public virtual BAssociation Association { get; set; }
        public virtual BDiscountFeeType DiscountFeeType { get; set; }
        public virtual BSeason Season { get; set; }
        public virtual ICollection<BMemberDiscount> BMemberDiscount { get; set; }
    }
}
