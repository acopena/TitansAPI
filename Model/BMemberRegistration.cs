using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMemberRegistration
    {
        public BMemberRegistration()
        {
            BMemberDiscount = new HashSet<BMemberDiscount>();
            BMemberFees = new HashSet<BMemberFees>();
            BMemberServiceFee = new HashSet<BMemberServiceFee>();
            BOrtrx = new HashSet<BOrtrx>();
        }

        public int MemberRegId { get; set; }
        public int MemberId { get; set; }
        public int UserId { get; set; }
        public int SeasonId { get; set; }
        public int WaiverId { get; set; }
        public bool WaiverIagree { get; set; }
        public DateTime DateReg { get; set; }
        public int? DivisionId { get; set; }
        public Guid? CartGuid { get; set; }

        public virtual BCart CartGu { get; set; }
        public virtual BDivision Division { get; set; }
        public virtual BMember Member { get; set; }
        public virtual BSeason Season { get; set; }
        public virtual BUsers User { get; set; }
        public virtual BWaiver Waiver { get; set; }
        public virtual ICollection<BMemberDiscount> BMemberDiscount { get; set; }
        public virtual ICollection<BMemberFees> BMemberFees { get; set; }
        public virtual ICollection<BMemberServiceFee> BMemberServiceFee { get; set; }
        public virtual ICollection<BOrtrx> BOrtrx { get; set; }
    }
}
