using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BEventDivision
    {
        public int EventDivisionId { get; set; }
        public int DivisionId { get; set; }
        public int EventNo { get; set; }

        public virtual BEvents EventNoNavigation { get; set; }
    }
}
