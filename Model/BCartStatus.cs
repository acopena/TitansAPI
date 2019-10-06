using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BCartStatus
    {
        public BCartStatus()
        {
            BCart = new HashSet<BCart>();
        }

        public int CartStatusId { get; set; }
        public string CartStatusName { get; set; }

        public virtual ICollection<BCart> BCart { get; set; }
    }
}
