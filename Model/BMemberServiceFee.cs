using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMemberServiceFee
    {
        public int MemberServiceFeeId { get; set; }
        public Guid CartGuid { get; set; }
        public int MemberRegId { get; set; }
        public int ServicesFeeId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? TrxDate { get; set; }

        public BCart CartGu { get; set; }
        public BMemberRegistration MemberReg { get; set; }
        public BServicesFee ServicesFee { get; set; }
    }
}
