using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BStatus
    {
        public BStatus()
        {
            BMember = new HashSet<BMember>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public ICollection<BMember> BMember { get; set; }
    }
}
