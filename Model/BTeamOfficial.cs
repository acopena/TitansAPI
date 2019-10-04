using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeamOfficial
    {
        public int TeamOfficialId { get; set; }
        public int OfficialId { get; set; }
        public int TeamId { get; set; }

        public BOfficial Official { get; set; }
        public BTeam Team { get; set; }
    }
}
