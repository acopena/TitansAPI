using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMemberDiscount
    {
        public int MemberDiscountId { get; set; }
        public Guid CartGuid { get; set; }
        public int MemberRegId { get; set; }
        public int DiscountFeeId { get; set; }
        public DateTime? DiscountFeeDate { get; set; }
        public decimal? DiscountFeeAmount { get; set; }
        public int DiscountFeeTypeId { get; set; }

        public virtual BCart CartGu { get; set; }
        public virtual BDiscountFees DiscountFee { get; set; }
        public virtual BMemberRegistration MemberReg { get; set; }
    }
}
