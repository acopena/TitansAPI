using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinicSchedule
    {
        public int ClinicScheduleId { get; set; }
        public DateTime? ClinicScheduleDate { get; set; }
        public int ClinicId { get; set; }
        public Guid? ClinicScheduleKey { get; set; }
        public string ClinicEndTime { get; set; }
        public string ClinicStartTime { get; set; }

        public BClinic Clinic { get; set; }
    }
}
