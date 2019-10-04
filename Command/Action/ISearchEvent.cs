using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface ISearchEvent
    {
        Task<List<SearchModel>> GetList(string search);
        Task<List<MemberRegisteredModel>> GetRegisterMembers(int NoOfDays);
    }
}
