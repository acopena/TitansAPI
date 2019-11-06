using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IOfficialEvent
    {
        Task<OfficialPageModel> GetList(int pageSize, int page, IMapper mapper, titansContext context);
        Task<List<OfficialModel>> GetRawList(IMapper mapper, titansContext context);
        Task<OfficialModel> GetOfficialById(int id, IMapper mapper, titansContext context);
        Task SaveOfficial(OfficialModel model, IMapper mapper, titansContext context);
    }
}
