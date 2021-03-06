﻿using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMemberFees
    {
        public int MemberFeeId { get; set; }
        public Guid CartGuid { get; set; }
        public int MemberRegId { get; set; }
        public int FeeTrxId { get; set; }
        public decimal FeeAmount { get; set; }
        public double Gst { get; set; }
        public double Pst { get; set; }
        public double Hst { get; set; }
        public double Qst { get; set; }
        public decimal TotalFee { get; set; }

        public virtual BCart CartGu { get; set; }
        public virtual BFeeTrx FeeTrx { get; set; }
        public virtual BMemberRegistration MemberReg { get; set; }
    }
}
