using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TitansAPI.Command.Models;
using TitansAPI.Model;
using System;

namespace TitansAPI.Command.Action
{
    public class TeamEvent : ITeamEvent
    {
        public async Task<List<TeamTitansModel>> GetList(int seasonId, int divisionId, IMapper _mapper, titansContext context)
        {
            List<TeamTitansModel> contentList = new List<TeamTitansModel>();
            var data = await context.BTeam
                .Include(s => s.BTeamPlayers)
                .Include(s => s.Division)
                .Select(s => s).ToListAsync();

            if (divisionId > 0)
                data = data.Where(s => s.DivisionId == divisionId).ToList();
            if (seasonId > 0)
                data = data.Where(s => s.SeasonId == seasonId).ToList();

            foreach (var d in data)
            {
                contentList.Add(SetTeamData(d, _mapper, null));
            }
            return contentList.OrderBy(s => s.TeamName).ToList();
        }

        public async Task<List<MemberProspectModel>> GetProspectMemberList(int divisionId, int seasonId, titansContext context)
        {
            List<MemberProspectModel> contentList = new List<MemberProspectModel>();
            var division = await context.BDivision.Where(s => s.DivisionId == divisionId).FirstOrDefaultAsync();
            if (division != null)
            {
                decimal startBirthYear = seasonId - division.MaximumAge.Value;
                decimal endBirthYear = seasonId - division.MinimumAge.Value;

                var regMember = await context.BMemberRegistration
                    //.Where(s => s.SeasonId == seasonId)
                    .Where(s => s.DivisionId == divisionId && s.SeasonId == seasonId)
                    .Select(s => s.MemberId).ToArrayAsync();

                contentList = await context.BMember
                    .Where(s => s.DateOfBirth.Value.Year >= startBirthYear && s.DateOfBirth.Value.Year <= endBirthYear)
                    //.Where(s => regMember.Contains(s.MemberId))
                    .Select(s => new MemberProspectModel
                    {
                        MemberId = s.MemberId,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        DateOfBirth = s.DateOfBirth.Value
                    }).ToListAsync();
            }
            return contentList.OrderBy(s => s.FirstName).ToList();
        }


        public async Task<TeamTitansModel> GetTeamById(int teamId, IMapper _mapper, titansContext context)
        {
            TeamTitansModel content = new TeamTitansModel();
            var data = await context.BTeam
             .Include(s => s.BTeamPlayers)
             .Include(s => s.BTeamOfficial)
             .Include(s => s.Division)
             .Where(s => s.TeamId == teamId)
             .Select(s => s).FirstOrDefaultAsync();
            content = SetTeamData(data, _mapper, context);
            return content;
        }

        static TeamTitansModel SetTeamData(BTeam src, IMapper _mapper, titansContext ctx)
        {
            TeamTitansModel data = new TeamTitansModel();
            data = _mapper.Map<TeamTitansModel>(src);

            if (ctx != null)
            {
                data.Rosters = new List<TeamPlayerModel>();
                foreach (var t in src.BTeamPlayers)
                {
                    TeamPlayerModel p = new TeamPlayerModel();
                    p.TeamPlayerId = t.TeamPlayerId;
                    p.MemberId = t.MemberId;
                    var member = ctx.BMember.Single(s => s.MemberId == t.MemberId);
                    p.FirstName = member.FirstName;
                    p.LastName = member.LastName;
                    p.DateOfBirth = member.DateOfBirth.Value;
                    data.Rosters.Add(p);
                }

                data.Rosters = data.Rosters.OrderBy(s => s.FirstName + " " + s.LastName).ToList();

                data.Officials = new List<TeamTitansOfficialModel>();

                foreach (var t in src.BTeamOfficial)
                {
                    TeamTitansOfficialModel p = new TeamTitansOfficialModel();
                    p.OfficialId = t.OfficialId;
                    p.TeamOfficialId = t.TeamOfficialId;

                    var official = ctx.BOfficial.Single(s => s.OfficialId == t.OfficialId);
                    p.FirstName = official.OfficialFirstName;
                    p.LastName = official.OfficialLastName;
                    p.CellPhone = official.CellPhone;
                    p.Email = official.EmailAddress;
                    p.positionId = official.PositionId;

                    p.positionName = ctx.BPosition.Where(s => s.PositionId == official.PositionId).Select(s => s.PositionName).FirstOrDefault();
                    data.Officials.Add(p);
                }
            }
            return data;

        }



        public async Task<List<PositionModel>> GetPositionList(titansContext context)
        {
            List<PositionModel> PositionList = new List<PositionModel>();

            PositionList = await context.BPosition
                .Where(s => s.PositionTypeId == 3)
                .Select(s => new PositionModel
                {
                    PositionId = s.PositionId,
                    PositionName = s.PositionName
                }).ToListAsync();

            return PositionList;
        }

        public async Task<List<PositionModel>> GetAllPositionList(titansContext context)
        {
            List<PositionModel> PositionList = new List<PositionModel>();
            PositionList = await context.BPosition
                .Select(s => new PositionModel
                {
                    PositionId = s.PositionId,
                    PositionName = s.PositionName
                }).ToListAsync();
            return PositionList;
        }

        public async Task<int> SaveTeam(TeamTitansModel model, titansContext context)
        {
            int TeamId = 0;
            try
            {
                string TeamName = model.DivisionName;
                if (model.Officials.Count > 0)
                {
                    foreach (var x in model.Officials)
                    {
                        TeamName += '-' + x.FirstName + ' ' + x.LastName;
                        break;
                    }
                }
                var team = await (from p in context.BTeam
                                  where p.TeamId == model.TeamId
                                  select p).FirstOrDefaultAsync();
                if (team == null)
                {
                    //Add team Here
                    BTeam t = new BTeam();
                    t.DivisionId = model.DivisionId;
                    t.SeasonId = model.SeasonId;
                    t.TeamName = TeamName;
                    t.CreatedUserId = model.CreatedUserId;
                    t.DateCreated = DateTime.Now;
                    t.AssociationId = model.AssociationId;
                    t.MaximumPlayer = 15;
                    t.MinimumPlayer = 5;
                    t.MinAge = 1;
                    t.MaxAge = 50;
                    t.IsPibnateam = true; ;
                    t.IsCompetitive = true; ;
                    await context.BTeam.AddAsync(t);
                    await context.SaveChangesAsync();
                    model.TeamId = t.TeamId;
                }
                else
                {
                    team.AssociationId = model.AssociationId;
                    team.DivisionId = model.DivisionId;
                    team.SeasonId = model.SeasonId;
                    team.TeamName = model.TeamName;
                    team.CreatedUserId = model.CreatedUserId;
                    team.IsCompetitive = model.IsCompetitive;
                    team.IsPibnateam = model.IsPibnateam;
                    team.DateUpdated = DateTime.Now;
                    await context.SaveChangesAsync();
                }

                TeamId = model.TeamId;

                //Remove existing official
                var xOfficial = await context.BTeamOfficial.Where(x => x.TeamId == model.TeamId).ToListAsync();
                context.BTeamOfficial.RemoveRange(xOfficial);
                foreach (var o in model.Officials)
                {
                    var official = await context.BTeamOfficial.Where(s => s.TeamOfficialId == o.TeamOfficialId).Select(s => s).FirstOrDefaultAsync();
                    if (official == null)
                    {
                        BTeamOfficial tOfficial = new BTeamOfficial();
                        tOfficial.TeamId = model.TeamId;
                        tOfficial.OfficialId = o.OfficialId;
                        await context.BTeamOfficial.AddAsync(tOfficial);
                    }
                }
                await context.SaveChangesAsync();

                //Check if the Member is remove on the current list
                var cRoster = await (context.BTeamPlayers.Where(s => s.TeamId == model.TeamId).Select(p => p)).ToListAsync();
                foreach (var r in cRoster)
                {
                    var isExist = model.Rosters.Where(s => s.TeamPlayerId == r.TeamPlayerId).Select(s => s).FirstOrDefault();
                    if (isExist == null)
                    {
                        context.BTeamPlayers.Remove(r);
                    }
                }
                await context.SaveChangesAsync();

                var NewRoster = model.Rosters.Where(s => s.TeamPlayerId == 0).Select(s => s).ToList();
                foreach (var r in NewRoster)
                {
                    if (r.TeamPlayerId <= 0)
                    {
                        BTeamPlayers roster = new BTeamPlayers();
                        roster.TeamId = model.TeamId;
                        roster.MemberId = r.MemberId;
                        roster.DateJoined = DateTime.Now;
                        await context.BTeamPlayers.AddAsync(roster);
                    }
                }
                await context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                string emsg = err.Message;
            }
            return TeamId;
        }
    }
}
