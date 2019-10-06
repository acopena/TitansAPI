using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BEventTeamConfirmation
    {
        public int EventTeamConfirmationId { get; set; }
        public int EventsTeamId { get; set; }
        public int MemberId { get; set; }
        public DateTime? EventTeamConfirmationDate { get; set; }
        public bool? EventConfirmationStatus { get; set; }

        public virtual BEventTeams EventsTeam { get; set; }
    }
}
