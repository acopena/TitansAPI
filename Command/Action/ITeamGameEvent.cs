using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface ITeamGameEvent
    {
        Task<List<TeamGameModel>> GetTeamGameByTeam(int SeasonId, int TeamId, int DivisionId, IMapper mapper, titansContext context);
        Task<TeamGameModel> GetTeamGameId(int TeamGameId, IMapper mapper, titansContext context);
        Task SaveTeamGameStat(TeamGameModel model, IMapper mapper, titansContext context);
    }
}
