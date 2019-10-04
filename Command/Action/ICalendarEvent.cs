using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface ICalendarEvent
    {
        Task<List<CalendarModel>> GetCalendarList();
        Task GetRemoveCalendar(int id);
        Task PostCalendar(CalendarModel src);
        Task DeleteSchedule(int id);
    }
}
