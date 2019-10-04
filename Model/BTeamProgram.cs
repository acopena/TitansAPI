using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTeamProgram
    {
        public int TeamProgramId { get; set; }
        public int TeamId { get; set; }
        public int ClinicProgramId { get; set; }

        public BClinicPrograms ClinicProgram { get; set; }
        public BTeam Team { get; set; }
    }
}
