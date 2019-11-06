using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface ISearchEvent
    {
        Task<List<SearchModel>> GetList(string search, titansContext context);
        Task<List<MemberRegisteredModel>> GetRegisterMembers(int NoOfDays, titansContext context);
    }
}
