using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BOrtrx
    {
        public int OrtrxId { get; set; }
        public string Orno { get; set; }
        public int MemberRegId { get; set; }
        public decimal? FeeAmount { get; set; }

        public virtual BMemberRegistration MemberReg { get; set; }
        public virtual BOrfile OrnoNavigation { get; set; }
    }
}
