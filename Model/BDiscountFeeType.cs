using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BDiscountFeeType
    {
        public BDiscountFeeType()
        {
            BDiscountFees = new HashSet<BDiscountFees>();
        }

        public int DiscountFeeTypeId { get; set; }
        public string DiscountFeeTypeName { get; set; }

        public ICollection<BDiscountFees> BDiscountFees { get; set; }
    }
}
