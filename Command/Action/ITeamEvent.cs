using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface ITeamEvent
    {
        Task<List<TeamModel>> GetList(int seasonId, int divisionId, IMapper _mapper);
        Task<List<MemberProspectModel>> GetProspectMemberList(int divisionId, int seasonId);
        Task<TeamModel> GetTeamById(int teamId, IMapper _mapper);
        Task<List<PositionModel>> GetPositionList();
        Task<List<PositionModel>> GetAllPositionList();
        Task<int> SaveTeam(TeamModel model);
    }
}
