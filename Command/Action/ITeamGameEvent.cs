using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface ITeamGameEvent
    {
        Task<List<TeamGameModel>> GetTeamGameByTeam(int SeasonId, int TeamId, int DivisionId);
        Task<TeamGameModel> GetTeamGameId(int TeamGameId);
        Task SaveTeamGameStat(TeamGameModel model);
    }
}
