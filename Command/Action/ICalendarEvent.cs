using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface ICalendarEvent
    {
        Task<List<CalendarModel>> GetCalendarList(IMapper mapper, titansContext context);
        Task GetRemoveCalendar(int id, titansContext context);
        Task PostCalendar(CalendarModel src, IMapper mapper, titansContext context);
        Task DeleteSchedule(int id, titansContext context);
    }
}
