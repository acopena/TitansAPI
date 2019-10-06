using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Command.Models
{
    public class TeamGameModel
    {
        public int TeamGameId{ get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamVsName{ get; set; }
        public int TeamVsScore{ get; set; }
        public int TeamScore{ get; set; }
        public Boolean TeamCourt { get; set; }
        public DateTime DatePlayed { get; set; }
        public string Notes{ get; set; }
        public List<TeamStatModel> TeamStat { get; set; }
        public int PostedById { get; set; }
    }
    public class TeamStatModel
    {
        public int TeamStatId { get; set; }
        public int TeamGameId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int Points { get; set; }
        public int FieldGoalMade { get; set; }
        public int FieldGoalAttemts { get; set; }
        public int FreeThrowsMade { get; set; }
        public int FreeThrowsAttemts { get; set; }
        public int ThreeFieldGoalMade { get; set; }
        public int ThreeFieldGoalAttemts { get; set; }
        public int OffensiveRebounds { get; set; }
        public int DefensiveRebounds { get; set; }
        public int Assits { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int TurnOvers { get; set; }
        public int PersonalFoul { get; set; }
    }
}
