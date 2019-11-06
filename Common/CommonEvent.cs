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
        public static async Task<List<BContactType>> GetContactTypeList(titansContext context)
        {
            return await context.BContactType
                .Select(s => s).ToListAsync();
        }

        public static async Task<int> GetDivisionId(int BirthYear, titansContext context)
        {
            int divisionId = 0;
            int CurrentAge = DateTime.Now.Year - BirthYear;
            var division = await context.BDivision
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
            return divisionId;
        }
    }
}
