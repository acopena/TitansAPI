using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeamDiscussion
    {
        public int TeamDiscussionId { get; set; }
        public DateTime DiscussionDate { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public string Notes { get; set; }

        public BTeam Team { get; set; }
        public BUsers User { get; set; }
    }
}
