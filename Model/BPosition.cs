using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BPosition
    {
        public BPosition()
        {
            BOfficial = new HashSet<BOfficial>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int? PositionTypeId { get; set; }

        public virtual BPositionType PositionType { get; set; }
        public virtual ICollection<BOfficial> BOfficial { get; set; }
    }
}
