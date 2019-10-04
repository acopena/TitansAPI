using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BFeeType
    {
        public BFeeType()
        {
            BFees = new HashSet<BFees>();
        }

        public int FeeTypeId { get; set; }
        public string FeeTypeName { get; set; }

        public ICollection<BFees> BFees { get; set; }
    }
}
