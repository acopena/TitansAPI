using System;
using System.Collections.Generic;
using System.Text;
using TitansAPI.Model;

namespace TitansAPI.Command
{
    public class DataContext<T>
    {
        public TReturn GetData<TReturn, TParameter>(TReturn DefaultValue)
        {

            //List<CalendarModel> List = new List<CalendarModel>();
            TReturn value  =  DefaultValue ;
            using (var ctx = new titansContext())
            {
               // value = ctx.BCalendar;
                        

            }
            return value;
        }

    }
}
