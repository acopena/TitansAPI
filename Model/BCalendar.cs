using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BCalendar
    {
        public int CalendarId { get; set; }
        public DateTime? DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
        public string Subject { get; set; }
        public int? PostedById { get; set; }
        public string Notes { get; set; }
        public DateTime? DatePosted { get; set; }
        public int? TeamId { get; set; }
    }
}
