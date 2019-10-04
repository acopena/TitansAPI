using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BSchedule
    {
        public int ScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string ScheduleStartTime { get; set; }
        public string ScheduleEndTime { get; set; }
        public string ScheduleDescription { get; set; }
        public int ScheduleTypeId { get; set; }
    }
}
