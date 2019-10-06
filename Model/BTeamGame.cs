using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeamGame
    {
        public BTeamGame()
        {
            BTeamStat = new HashSet<BTeamStat>();
        }

        public int TeamGameId { get; set; }
        public int TeamId { get; set; }
        public string TeamVsName { get; set; }
        public int TeamVsScore { get; set; }
        public bool TeamCourt { get; set; }
        public DateTime DatePlayed { get; set; }
        public int PostedById { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }

        public virtual BUsers PostedBy { get; set; }
        public virtual BTeam Team { get; set; }
        public virtual ICollection<BTeamStat> BTeamStat { get; set; }
    }
}
