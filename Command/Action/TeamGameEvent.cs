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
    public class TeamGameEvent : ITeamGameEvent
    {
        public async Task<List<TeamGameModel>> GetTeamGameByTeam(int SeasonId, int TeamId, int DivisionId, IMapper _mapper, titansContext context)
        {
            List<TeamGameModel> teamGameModel = new List<TeamGameModel>();
            var model = context.BTeamGame
                    .Include(s => s.Team)
                    .Include(s => s.BTeamStat)
                    .Where(s => s.EndDate == null)
                    .Select(s => s);

            if (SeasonId > 0)
                model = model.Where(s => s.Team.SeasonId == SeasonId);

            if (DivisionId > 0)
                model = model.Where(s => s.Team.DivisionId == DivisionId);

            if (TeamId > 0)
                model = model.Where(s => s.TeamId == TeamId);
            return _mapper.Map<List<TeamGameModel>>(await model.ToListAsync());
        }

        public async Task<TeamGameModel> GetTeamGameId(int TeamGameId, IMapper _mapper, titansContext context)
        {
            TeamGameModel game = new TeamGameModel();
            try
            {
                game = await (from p in context.BTeamGame
                              where p.TeamGameId == TeamGameId && p.EndDate == null
                              select _mapper.Map<TeamGameModel>(p)).FirstOrDefaultAsync();
                if (game != null)
                {
                    game.TeamStat = new List<TeamStatModel>();
                    var gameStat = await (context.BTeamStat.Include(s => s.Member)
                        .Where(s => s.TeamGameId == TeamGameId)
                        .OrderBy(s => s.Member.FirstName + " " + s.Member.LastName)).ToListAsync();
                    foreach (var r in gameStat)
                    {
                        TeamStatModel stat = _mapper.Map<TeamStatModel>(r);
                        game.TeamStat.Add(stat);
                    }
                }
                return game;
            }
            catch (Exception err)
            {
                string error = err.Message;
                return game;
            }

        }

        public async Task SaveTeamGameStat(TeamGameModel model, IMapper _mapper, titansContext context)
        {
            try
            {

                var game = await context.BTeamGame
                    .Where(s => s.TeamGameId == model.TeamGameId).FirstOrDefaultAsync();
                if (game == null)
                {
                    BTeamGame g = new BTeamGame();
                    _mapper.Map(model, g);
                    await context.BTeamGame.AddAsync(g);
                    await context.SaveChangesAsync();
                    model.TeamGameId = g.TeamGameId;
                }
                else
                {
                    _mapper.Map(model, game);
                    await context.SaveChangesAsync();
                }

                var removeTeamStat = await context.BTeamStat.Where(s => s.TeamGameId == model.TeamGameId).ToListAsync();
                context.BTeamStat.RemoveRange(removeTeamStat);
                foreach (var r in model.TeamStat)
                {
                    BTeamStat stat = new BTeamStat();                    
                    _mapper.Map(r, stat);
                    stat.TeamGameId = model.TeamGameId;
                    await context.BTeamStat.AddAsync(stat);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                string error = err.Message;
            }
        }

    }
}
