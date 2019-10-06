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
        public async Task<List<TeamGameModel>> GetTeamGameByTeam(int SeasonId, int TeamId, int DivisionId)
        {
            List<TeamGameModel> teamGameModel = new List<TeamGameModel>();
            using (var ctx = new titansContext())
            {

                var model = from p in ctx.BTeamGame
                            where p.EndDate == null
                            select p;

                if (SeasonId > 0)
                {
                    model = model.Where(s => s.Team.SeasonId == SeasonId);
                }

                if (DivisionId > 0)
                {
                    model = model.Where(s => s.Team.DivisionId == DivisionId);
                }

                if (TeamId > 0)
                {
                    model = model.Where(s => s.TeamId == TeamId);
                }



                teamGameModel = await (from p in model
                                       select new TeamGameModel
                                       {
                                           TeamGameId = p.TeamGameId,
                                           TeamName = p.Team.TeamName,
                                           TeamId = p.TeamId,
                                           TeamVsName = p.TeamVsName,
                                           TeamVsScore = p.TeamVsScore,
                                           TeamScore = p.BTeamStat.Sum(s => s.Points),
                                           TeamCourt = p.TeamCourt,
                                           DatePlayed = p.DatePlayed,
                                           Notes = p.Notes
                                       }).ToListAsync();
            }
            return teamGameModel;
        }

        public async Task<TeamGameModel> GetTeamGameId(int TeamGameId)
        {
            TeamGameModel game = new TeamGameModel();
            try
            {

                using (var ctx = new titansContext())
                {
                    game = await (from p in ctx.BTeamGame
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
                        var gameStat = await (ctx.BTeamStat.Include(s => s.Member)
                            .Where(s => s.TeamGameId == TeamGameId)
                            .OrderBy(s => s.Member.FirstName + " " + s.Member.LastName)).ToListAsync();
                        foreach (var r in gameStat)
                        {
                            TeamStatModel stat = new TeamStatModel();
                            stat.TeamStatId = r.TeamStatId;
                            stat.TeamGameId = r.TeamGameId;
                            stat.MemberId = r.MemberId;
                            stat.MemberName = r.Member.FirstName + " " + r.Member.LastName;
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
                            game.TeamStat.Add(stat);
                        }
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

        public async Task SaveTeamGameStat(TeamGameModel model)
        {
            try
            {
                using (var ctx = new titansContext())
                {
                    var game = await ctx.BTeamGame.Where(s => s.TeamGameId == model.TeamGameId).FirstOrDefaultAsync();
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
                        await ctx.BTeamGame.AddAsync(g);
                        await ctx.SaveChangesAsync();
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
                        await ctx.SaveChangesAsync();
                    }

                    var removeTeamStat = await ctx.BTeamStat.Where(s => s.TeamGameId == model.TeamGameId).ToListAsync();
                    ctx.BTeamStat.RemoveRange(removeTeamStat);


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
                        await ctx.BTeamStat.AddAsync(stat);
                    }

                    await ctx.SaveChangesAsync();

                }

            }
            catch (Exception err)
            {
                string error = err.Message;
            }
        }

    }
}
