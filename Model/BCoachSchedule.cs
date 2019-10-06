using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BCoachSchedule
    {
        public int CoachScheduleId { get; set; }
        public DateTime CoachScheduleDate { get; set; }
        public int UserId { get; set; }
        public int? TeamId { get; set; }
        public bool? CoachScheduleAttend { get; set; }
        public bool? CoachScheduleAttended { get; set; }
        public string CoachScheduleNotes { get; set; }

        public virtual BUsers User { get; set; }
    }
}
