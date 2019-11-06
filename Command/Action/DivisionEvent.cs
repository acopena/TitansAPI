using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public class DivisionEvent : IDivisionEvent
    {
        public async Task<List<DivisionModel>> GetList(IMapper _mapper, titansContext context)
        {
            //var data = await context.BDivision
            //    .Select(s => s).ToListAsync();
            return _mapper.Map<List<DivisionModel>>(await context.BDivision
                .Select(s => s).ToListAsync());
        }

        public async Task<DivisionModel> GetDivisionById(int id, IMapper _mapper, titansContext context)
        {
                return await context.BDivision
                    .Where(s => s.DivisionId == id)
                    .Select(s => _mapper.Map<DivisionModel>(s)).FirstOrDefaultAsync();
        }

        public async Task<List<DivisionModel>> GetDivisionByTypeId(int id, IMapper _mapper, titansContext context)
        {
            List<DivisionModel> contentList = new List<DivisionModel>();
       
                var data = await context.BDivision
                    .Where(s => s.DivisionTypeId == id)
                    .Select(s => s).ToListAsync();
                return _mapper.Map<List<DivisionModel>>(data);
       
        }
    }
}
