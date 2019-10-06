using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeamContact
    {
        public int TeamContactId { get; set; }
        public int? TeamId { get; set; }
        public int? ContactId { get; set; }

        public virtual BTeam Team { get; set; }
    }
}
