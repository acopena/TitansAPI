using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BPositionType
    {
        public BPositionType()
        {
            BPosition = new HashSet<BPosition>();
        }

        public int PositionTypeId { get; set; }
        public string PositionTypeName { get; set; }

        public virtual ICollection<BPosition> BPosition { get; set; }
    }
}
