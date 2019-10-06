using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BFeeTrx
    {
        public BFeeTrx()
        {
            BMemberFees = new HashSet<BMemberFees>();
        }

        public int FeeTrxId { get; set; }
        public int FeeId { get; set; }
        public int SeasonId { get; set; }
        public int AssociationId { get; set; }
        public decimal FeeAmount { get; set; }
        public double Gst { get; set; }
        public double Pst { get; set; }
        public double Hst { get; set; }
        public double Qst { get; set; }

        public virtual BAssociation Association { get; set; }
        public virtual BFees Fee { get; set; }
        public virtual ICollection<BMemberFees> BMemberFees { get; set; }
    }
}
