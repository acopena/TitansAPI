using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public class CalendarEvent : ICalendarEvent
    {
        public async Task<List<CalendarModel>> GetCalendarList(IMapper _mapper, titansContext _context)
        {
            List<CalendarModel> List = new List<CalendarModel>();
            DateTime today = DateTime.Now.AddDays(-60);
            var data = await _context.BCalendar
                .Where(s => s.DateTimeStart.Value >= today)
                .Select(s => s).ToListAsync();
            List = _mapper.Map<List<CalendarModel>>(data);
            return List;
        }

        public async Task GetRemoveCalendar(int id, titansContext _context)
        {

            var calendar = await _context.BCalendar.Where(s => s.CalendarId == id).FirstOrDefaultAsync();
            if (calendar != null)
            {
                var data = await _context.BCalendar
                .Where(s => s.CalendarId == id)
                .Select(s => s).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.BCalendar.Remove(data);
                    await _context.SaveChangesAsync();
                }
            }

        }


        public async Task PostCalendar(CalendarModel src, IMapper _mapper, titansContext _context)
        {
            CalendarModel model = new CalendarModel();
            var data = await _context.BCalendar
                 .Where(s => s.CalendarId == src.CalendarId)
                 .Select(s => s).FirstOrDefaultAsync();
            if (data == null)
            {
                BCalendar c = _mapper.Map<BCalendar>(src);
                await _context.BCalendar.AddAsync(c);
            }
            else
            {
                _mapper.Map(src, data);
            }

            await _context.SaveChangesAsync();


        }

        public async Task DeleteSchedule(int id, titansContext _context)
        {

            var data = await _context.BCalendar
                 .Where(s => s.CalendarId == id)
                 .Select(s => s).FirstOrDefaultAsync();
            if (data != null)
            {
                _context.BCalendar.Remove(data);
                await _context.SaveChangesAsync();
            }

        }
    }
}
