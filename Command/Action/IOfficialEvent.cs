using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface IOfficialEvent
    {
        Task<OfficialPageModel> GetList(int pageSize, int page);
        Task<List<OfficialModel>> GetRawList();
        Task<OfficialModel> GetOfficialById(int id);
        Task SaveOfficial(OfficialModel model);
    }
}
