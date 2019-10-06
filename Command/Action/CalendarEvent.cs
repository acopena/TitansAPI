using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public class CalendarEvent : ICalendarEvent
    {
        public async Task<List<CalendarModel>> GetCalendarList()
        {
            List<CalendarModel> List = new List<CalendarModel>();
            using (var ctx = new titansContext())
            {
                DateTime today = DateTime.Now.AddDays(-60);

                List = await ctx.BCalendar
                    .Where(s => s.DateTimeStart.Value >= today)

                    .Select(s => new CalendarModel()
                    {
                        CalendarId = s.CalendarId,
                        Start = s.DateTimeStart.Value,
                        End = s.DateTimeEnd.Value,
                        Title = s.Subject,
                        Subject = s.Notes,
                        Color = ""
                    }).ToListAsync();

            }
            return List;
        }

        public async Task GetRemoveCalendar(int id)
        {
            using (var ctx = new titansContext())
            {
                var calendar = await ctx.BCalendar.Where(s => s.CalendarId == id).FirstOrDefaultAsync();
                if (calendar != null)
                {
                    var data = await ctx.BCalendar
                    .Where(s => s.CalendarId == id)
                    .Select(s => s).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        ctx.BCalendar.Remove(data);
                        await ctx.SaveChangesAsync();
                    }
                }
            }
        }


        public async Task PostCalendar(CalendarModel src)
        {
            CalendarModel model = new CalendarModel();
            using (var ctx = new titansContext())
            {

                var data = await ctx.BCalendar
                     .Where(s => s.CalendarId == src.CalendarId)
                     .Select(s => s).FirstOrDefaultAsync();
                if (data == null)
                {
                    BCalendar c = new BCalendar();
                    c.Subject = src.Title;
                    c.Notes = src.Subject;
                    c.DateTimeStart = src.Start;
                    c.DateTimeEnd = src.End;
                    c.TeamId = src.TeamId;
                    c.PostedById = src.UserId;
                    c.DatePosted = DateTime.Now;
                    await ctx.BCalendar.AddAsync(c);
                }
                else
                {
                    data.Subject = src.Title;
                    data.Notes = src.Subject;
                    data.DateTimeStart = src.Start;
                    data.DateTimeEnd = src.End;
                    data.TeamId = src.TeamId;
                    data.PostedById = src.UserId;
                    data.DatePosted = DateTime.Now;
                }
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteSchedule(int id)
        {
            using (var ctx = new titansContext())
            {
                var data = await ctx.BCalendar
                     .Where(s => s.CalendarId == id)
                     .Select(s => s).FirstOrDefaultAsync();
                if (data != null)
                {
                    ctx.BCalendar.Remove(data);
                    await ctx.SaveChangesAsync();
                }
            }
        }
    }
}
