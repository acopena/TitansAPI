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
        public async Task<OfficialPageModel> GetList(int pageSize, int page)
        {
            var model = new OfficialPageModel(); 
            List<OfficialModel> contentList = new List<OfficialModel>();
            using (var ctx = new titansContext())
            {

                var list = from p in ctx.BOfficial
                           where p.OfficialStatusId == 1
                    select new OfficialModel {
                        OfficialId = p.OfficialId,
                        FirstName = p.OfficialFirstName,
                        LastName = p.OfficialLastName,
                        EmailAddress = p.EmailAddress,
                        CellPhone = p.CellPhone,
                        PositionId = p.PositionId,
                        PositionName = p.Position.PositionName,
                        OfficialStatusId = p.OfficialStatusId,
                    };

                var data = await PaginatedList<OfficialModel>.CreateAsync(list.AsNoTracking(), page, pageSize);
                model.RecordCount = data.TotalRecord;
                model.data = data;
                return model;
            }
        }

        public async Task<OfficialModel> GetOfficialById(int id)
        {

            OfficialModel model = new OfficialModel();
            using (var ctx = new titansContext())
            {
                model = await (from p in ctx.BOfficial
                           where p.OfficialId == id
                           select new OfficialModel
                           {
                               OfficialId = p.OfficialId,
                               FirstName = p.OfficialFirstName,
                               LastName = p.OfficialLastName,
                               EmailAddress = p.EmailAddress,
                               CellPhone = p.CellPhone,
                               PositionId = p.PositionId,
                               PositionName = p.Position.PositionName,
                               OfficialStatusId = p.OfficialStatusId,
                           }).FirstOrDefaultAsync();
            }
            return model;
        }

        public async Task<List<OfficialModel>> GetRawList()
        {
            
            List<OfficialModel> contentList = new List<OfficialModel>();
            using (var ctx = new titansContext())
            {
                var data  = from p in ctx.BOfficial
                            orderby p.OfficialLastName, p.OfficialFirstName
                           select new OfficialModel
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

                contentList = await data.ToListAsync();
            }
            return contentList;
        }

        public async Task SaveOfficial(OfficialModel model)
        {
            try
            {
                using (var ctx = new titansContext())
                {
                    var official = await ctx.BOfficial.Where(s => s.OfficialId == model.OfficialId).FirstOrDefaultAsync();
                    if (official == null)
                    {
                        BOfficial o = new BOfficial();
                        o.OfficialFirstName = model.FirstName;
                        o.OfficialLastName = model.LastName;
                        o.PositionId = model.PositionId;
                        o.EmailAddress = model.EmailAddress;
                        o.TelNo = model.CellPhone;
                        o.CellPhone = model.CellPhone;
                        o.AssociationId = 1;
                        o.OfficialStatusId = model.OfficialStatusId;
                        o.Address = "-";
                        o.Gender = "M";

                        await ctx.BOfficial.AddAsync(o);

                    }
                    else
                    {
                        official.OfficialFirstName = model.FirstName;
                        official.OfficialFirstName = model.FirstName;
                        official.OfficialLastName = model.LastName;
                        official.PositionId = model.PositionId;
                        official.EmailAddress = model.EmailAddress;
                        official.TelNo = model.CellPhone;
                        official.CellPhone = model.CellPhone;
                        official.OfficialStatusId = model.OfficialStatusId;

                    }
                    await ctx.SaveChangesAsync();
                }
            }
            catch(Exception ex)
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
