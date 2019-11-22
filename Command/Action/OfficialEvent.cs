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
    public class OfficialEvent : IOfficialEvent
    {
        public async Task<OfficialPageModel> GetList(int pageSize, int page, IMapper _mapper, titansContext context)
        {
            var model = new OfficialPageModel();
            List<OfficialModel> contentList = new List<OfficialModel>();

            var list = from p in context.BOfficial
                       where p.OfficialStatusId == 1
                       select new OfficialModel()
                       {
                           OfficialId = p.OfficialId,
                           FirstName = p.OfficialFirstName,
                           LastName = p.OfficialLastName,
                           EmailAddress = p.EmailAddress,
                           CellPhone = p.CellPhone,
                           PositionId = p.PositionId,
                           PositionName = p.Position.PositionName,
                           OfficialStatusId = p.OfficialStatusId,
                       };
            var data = await PaginatedList<OfficialModel>.CreateAsync(list.AsTracking(), page, pageSize);
            model.RecordCount = data.TotalRecord;
            model.data = data;
            return model;

        }

        public async Task<OfficialModel> GetOfficialById(int id, IMapper mapper, titansContext context)
        {

            return await context.BOfficial
                .Include(s => s.Position)
                .Where(s => s.OfficialId == id)
                .Select(s => mapper.Map<OfficialModel>(s)).FirstOrDefaultAsync();

        }

        public async Task<List<OfficialModel>> GetRawList(IMapper mapper, titansContext context)
        {            
            var data = await context.BOfficial
                .Include(s => s.Position)
                .OrderBy(s => s.OfficialLastName)
                .Select(s => s).ToListAsync();
            var oList = mapper.Map<List<OfficialModel>>(data);
            return oList.OrderBy(s => s.LastName).ToList();

        }

        public async Task SaveOfficial(OfficialModel model, IMapper mapper, titansContext context)
        {
            try
            {
                var official = await context.BOfficial.Where(s => s.OfficialId == model.OfficialId).FirstOrDefaultAsync();
                if (official == null)
                {
                    BOfficial o = mapper.Map<BOfficial>(model);
                    o.AssociationId = 1;
                    o.Address = "-";
                    o.Gender = "M";
                    await context.BOfficial.AddAsync(o);
                }
                else
                {
                    official = mapper.Map<BOfficial>(model);
                }
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }

    public class OfficialPageModel
    {
        public List<OfficialModel> data { get; set; }
        public int RecordCount { get; set; }
    }
}
