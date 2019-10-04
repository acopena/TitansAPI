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

        public BAssociation Association { get; set; }
        public BDiscountFeeType DiscountFeeType { get; set; }
        public BSeason Season { get; set; }
        public ICollection<BMemberDiscount> BMemberDiscount { get; set; }
    }
}
