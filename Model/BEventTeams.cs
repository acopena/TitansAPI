using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BEventTeams
    {
        public BEventTeams()
        {
            BEventTeamConfirmation = new HashSet<BEventTeamConfirmation>();
        }

        public int EventsTeamId { get; set; }
        public int EventNo { get; set; }
        public int TeamId { get; set; }
        public DateTime DateJoin { get; set; }
        public int PostedById { get; set; }

        public virtual BEvents EventNoNavigation { get; set; }
        public virtual BTeam Team { get; set; }
        public virtual ICollection<BEventTeamConfirmation> BEventTeamConfirmation { get; set; }
    }
}
