using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Model;

namespace TitansAPI.Common
{
    public class CommonEvent
    {
        public static async Task<List<BContactType>> GetContactTypeList()
        {
            List<BContactType> List = new List<BContactType>();
            using (var ctx = new titansContext())
            {
                List = await ctx.BContactType
                    .Select(s => s).ToListAsync();

            }
            return List;
        }

        public static async Task<int> GetDivisionId(int BirthYear)
        {
            int divisionId = 0;
            int CurrentAge = DateTime.Now.Year - BirthYear;
            using (var ctx = new titansContext())
            {
                var division = await ctx.BDivision
                    .Where(s => s.DivisionTypeId == 2 && s.MinimumAge <= CurrentAge && s.MaximumAge >= CurrentAge)
                    .Select(s => s).FirstOrDefaultAsync();
                if (division != null)
                {
                    divisionId = division.DivisionId;
                }
                else
                {
                    divisionId = 23; // all division
                }



            }
            return divisionId;
        }
    }
}
