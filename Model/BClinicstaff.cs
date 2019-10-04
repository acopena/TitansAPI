using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicstaff
    {
        public int ClinicStaffId { get; set; }
        public int ClinicId { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }

        public BPosition Position { get; set; }
        public BUsers User { get; set; }
    }
}
