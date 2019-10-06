using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeamStat
    {
        public int TeamStatId { get; set; }
        public int TeamGameId { get; set; }
        public int MemberId { get; set; }
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

        public virtual BMember Member { get; set; }
        public virtual BTeamGame TeamGame { get; set; }
    }
}
