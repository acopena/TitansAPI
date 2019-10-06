using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BEventType
    {
        public BEventType()
        {
            BEvents = new HashSet<BEvents>();
        }

        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }

        public virtual ICollection<BEvents> BEvents { get; set; }
    }
}
