using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeamPlayers
    {
        public int TeamPlayerId { get; set; }
        public int TeamId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateJoined { get; set; }
        public int PostedById { get; set; }

        public virtual BMember Member { get; set; }
        public virtual BTeam Team { get; set; }
    }
}
