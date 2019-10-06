using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BFees
    {
        public BFees()
        {
            BFeeTrx = new HashSet<BFeeTrx>();
        }

        public int FeeId { get; set; }
        public string FeeName { get; set; }
        public bool RequiredFees { get; set; }
        public int? FeeTypeId { get; set; }

        public virtual BFeeType FeeType { get; set; }
        public virtual ICollection<BFeeTrx> BFeeTrx { get; set; }
    }
}
