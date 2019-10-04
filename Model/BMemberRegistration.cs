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

        public BCart CartGu { get; set; }
        public BDivision Division { get; set; }
        public BMember Member { get; set; }
        public BSeason Season { get; set; }
        public BUsers User { get; set; }
        public BWaiver Waiver { get; set; }
        public ICollection<BMemberDiscount> BMemberDiscount { get; set; }
        public ICollection<BMemberFees> BMemberFees { get; set; }
        public ICollection<BMemberServiceFee> BMemberServiceFee { get; set; }
        public ICollection<BOrtrx> BOrtrx { get; set; }
    }
}
