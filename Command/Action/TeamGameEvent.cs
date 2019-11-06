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
            teamGameModel = _mapper.Map<List<TeamGameModel>>(await model.ToListAsync());


            return teamGameModel;
        }

        public async Task<TeamGameModel> GetTeamGameId(int TeamGameId, IMapper _mapper, titansContext context)
        {
            TeamGameModel game = new TeamGameModel();
            try
            {


                game = await (from p in context.BTeamGame
                              where p.TeamGameId == TeamGameId && p.EndDate == null
                              select new TeamGameModel
                              {
                                  TeamGameId = p.TeamGameId,
                                  TeamId = p.TeamId,
                                  TeamName = p.Team.TeamName,
                                  TeamVsName = p.TeamVsName,
                                  TeamVsScore = p.TeamVsScore,
                                  TeamScore = p.BTeamStat.Sum(s => s.Points),
                                  TeamCourt = p.TeamCourt,
                                  DatePlayed = p.DatePlayed,
                                  Notes = p.Notes
                              }).FirstOrDefaultAsync();
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
                    g.TeamId = model.TeamId;
                    g.TeamVsName = model.TeamVsName;
                    g.TeamCourt = model.TeamCourt;
                    g.Notes = model.Notes;
                    g.PostedById = model.PostedById;
                    g.TeamVsScore = model.TeamVsScore;
                    g.DatePlayed = model.DatePlayed;
                    await context.BTeamGame.AddAsync(g);
                    await context.SaveChangesAsync();
                    model.TeamGameId = g.TeamGameId;
                }
                else
                {
                    game.TeamVsName = model.TeamVsName;
                    game.TeamCourt = model.TeamCourt;
                    game.Notes = model.Notes;
                    game.PostedById = model.PostedById;
                    game.TeamVsScore = model.TeamVsScore;
                    game.DatePlayed = model.DatePlayed;
                    await context.SaveChangesAsync();
                }

                var removeTeamStat = await context.BTeamStat.Where(s => s.TeamGameId == model.TeamGameId).ToListAsync();
                context.BTeamStat.RemoveRange(removeTeamStat);


                foreach (var r in model.TeamStat)
                {
                    BTeamStat stat = new BTeamStat();

                    stat.TeamGameId = model.TeamGameId;
                    stat.MemberId = r.MemberId;
                    stat.Points = r.Points;
                    stat.FieldGoalAttemts = r.FieldGoalAttemts;
                    stat.FieldGoalMade = r.FieldGoalMade;
                    stat.FreeThrowsAttemts = r.FreeThrowsAttemts;
                    stat.FreeThrowsMade = r.FreeThrowsMade;
                    stat.ThreeFieldGoalAttemts = r.ThreeFieldGoalAttemts;
                    stat.ThreeFieldGoalMade = r.ThreeFieldGoalMade;
                    stat.OffensiveRebounds = r.OffensiveRebounds;
                    stat.DefensiveRebounds = r.DefensiveRebounds;
                    stat.Assits = r.Assits;
                    stat.Steals = r.Steals;
                    stat.Blocks = r.Blocks;
                    stat.TurnOvers = r.TurnOvers;
                    stat.PersonalFoul = r.PersonalFoul;
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
