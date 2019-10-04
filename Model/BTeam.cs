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
            BTeamOfficial = new HashSet<BTeamOfficial>();
            BTeamPlayers = new HashSet<BTeamPlayers>();
            BTeamProgram = new HashSet<BTeamProgram>();
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

        public BDivision Division { get; set; }
        public BServicesFee ServiceFee { get; set; }
        public ICollection<BEventTeams> BEventTeams { get; set; }
        public ICollection<BLeagueSchedule> BLeagueSchedule { get; set; }
        public ICollection<BTeamContact> BTeamContact { get; set; }
        public ICollection<BTeamDiscussion> BTeamDiscussion { get; set; }
        public ICollection<BTeamOfficial> BTeamOfficial { get; set; }
        public ICollection<BTeamPlayers> BTeamPlayers { get; set; }
        public ICollection<BTeamProgram> BTeamProgram { get; set; }
    }
}
