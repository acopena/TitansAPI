﻿using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BSeason
    {
        public BSeason()
        {
            BDiscountFees = new HashSet<BDiscountFees>();
            BMemberRegistration = new HashSet<BMemberRegistration>();
            BSiteApprover = new HashSet<BSiteApprover>();
        }

        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<BDiscountFees> BDiscountFees { get; set; }
        public virtual ICollection<BMemberRegistration> BMemberRegistration { get; set; }
        public virtual ICollection<BSiteApprover> BSiteApprover { get; set; }
    }
}
