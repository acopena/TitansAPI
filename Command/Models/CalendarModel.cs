using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Command.Models
{
    public class CalendarModel
    {
        public int CalendarId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Subject { get; set; }
        public int UserId{ get; set; }
        public int? TeamId{ get; set; }
        
    }

    public class CalendarUrlModel
    {
        public int CalendarId { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Subject { get; set; }
        public int UserId { get; set; }
        public int? TeamId { get; set; }

    }
}
