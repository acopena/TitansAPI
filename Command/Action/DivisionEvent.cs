using AutoMapper;
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
    public class DivisionEvent: IDivisionModel
    {
        public async Task<List<BDivision>> GetList()
        {
            List<BDivision> contentList = new List<BDivision>();
            using (var ctx = new PBAContext())
            {
                contentList = await ctx.BDivision
                    .Select(s => s).ToListAsync();

            }
            return contentList;
        }

        public async Task<BDivision> GetDivisionById(int id)
        {
            BDivision model = new BDivision();
            using (var ctx = new PBAContext())
            {
                model = await ctx.BDivision
                    .Where(s => s.DivisionId == id)
                    .Select(s => s).FirstOrDefaultAsync();

                
            }
            return model;
        }

        public async Task<IEnumerable<BDivision>> GetDivisionByTypeId(int id)
        {
            List<BDivision> contentList = new List<BDivision>();
            using (var ctx = new PBAContext())
            {
                contentList = await ctx.BDivision
                    .Where(s=>s.DivisionTypeId == id)
                    .Select(s => s).ToListAsync();


            }
            return contentList;
        }
    }
}
