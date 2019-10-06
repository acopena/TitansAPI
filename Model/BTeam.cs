using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeam
    {
        public BTeam()
        {
            BEventTeams = new HashSet<BEventTeams>();
            BLeagueSchedule = new HashSet<BLeagueSchedule>();
            BTeamContact = new HashSet<BTeamContact>();
            BTeamDiscussion = new HashSet<BTeamDiscussion>();
            BTeamGame = new HashSet<BTeamGame>();
            BTeamOfficial = new HashSet<BTeamOfficial>();
            BTeamPlayers = new HashSet<BTeamPlayers>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int? AssociationId { get; set; }
        public int? DivisionId { get; set; }
        public int? MaximumPlayer { get; set; }
        public int? MinimumPlayer { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CreatedUserId { get; set; }
        public decimal? MinAge { get; set; }
        public decimal? MaxAge { get; set; }
        public int? SeasonId { get; set; }
        public bool? IsPibnateam { get; set; }
        public decimal? TeamFee { get; set; }
        public int? ServiceFeeId { get; set; }
        public bool? IsCompetitive { get; set; }

        public virtual BDivision Division { get; set; }
        public virtual BServicesFee ServiceFee { get; set; }
        public virtual ICollection<BEventTeams> BEventTeams { get; set; }
        public virtual ICollection<BLeagueSchedule> BLeagueSchedule { get; set; }
        public virtual ICollection<BTeamContact> BTeamContact { get; set; }
        public virtual ICollection<BTeamDiscussion> BTeamDiscussion { get; set; }
        public virtual ICollection<BTeamGame> BTeamGame { get; set; }
        public virtual ICollection<BTeamOfficial> BTeamOfficial { get; set; }
        public virtual ICollection<BTeamPlayers> BTeamPlayers { get; set; }
    }
}
