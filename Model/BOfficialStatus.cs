using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BOfficialStatus
    {
        public BOfficialStatus()
        {
            BOfficial = new HashSet<BOfficial>();
        }

        public int OfficialStatusId { get; set; }
        public string OfficialStatusName { get; set; }

        public virtual ICollection<BOfficial> BOfficial { get; set; }
    }
}
