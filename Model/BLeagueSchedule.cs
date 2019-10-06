using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BLeagueSchedule
    {
        public int LeagueScheduleId { get; set; }
        public string LeagueVenue { get; set; }
        public string LeagueVs { get; set; }
        public bool? LeagueStatus { get; set; }
        public int? LeagueScore { get; set; }
        public int? LeagueScoreVs { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public DateTime? LeagueDate { get; set; }
        public int? TeamId { get; set; }
        public int? EventNo { get; set; }

        public virtual BEvents EventNoNavigation { get; set; }
        public virtual BTeam Team { get; set; }
    }
}
