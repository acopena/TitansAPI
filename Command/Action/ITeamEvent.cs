using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface ITeamEvent
    {
        Task<List<TeamTitansModel>> GetList(int seasonId, int divisionId, IMapper _mapper, titansContext context);
        Task<List<MemberProspectModel>> GetProspectMemberList(int divisionId, int seasonId, titansContext context);
        Task<TeamTitansModel> GetTeamById(int teamId, IMapper _mapper, titansContext context);
        Task<List<PositionModel>> GetPositionList(titansContext context);
        Task<List<PositionModel>> GetAllPositionList(titansContext context);
        Task<int> SaveTeam(TeamTitansModel model, titansContext context);
    }
}
