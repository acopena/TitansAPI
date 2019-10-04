﻿using AutoMapper;
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
        public async Task<List<TeamModel>> GetList(int seasonId,int divisionId,IMapper _mapper)
        {
            List<TeamModel> contentList = new List<TeamModel>();
            using (var ctx = new PBAContext())
            {
                var data = await ctx.BTeam
                    .Include(s => s.BTeamPlayers)
                    .Include(s => s.Division)
                    .Select(s => s).ToListAsync();

                if (divisionId > 0)
                {
                    data = data.Where(s => s.DivisionId == divisionId).ToList();
                }
                if (seasonId > 0)
                {
                    data = data.Where(s => s.SeasonId == seasonId).ToList();
                }

                foreach (var d in data)
                {

                    contentList.Add(SetTeamData(d, _mapper, null));
                }

            }
            return contentList.OrderBy(s=>s.TeamName).ToList();
        }

        public async Task<List<MemberProspectModel>> GetProspectMemberList(int divisionId,int seasonId)
        {
            List<MemberProspectModel> contentList = new List<MemberProspectModel>();
            using (var ctx = new PBAContext())
            {
                var division = await ctx.BDivision.Where(s => s.DivisionId == divisionId).FirstOrDefaultAsync();
                if (division != null)
                {
                    decimal startBirthYear = seasonId - division.MaximumAge.Value;
                    decimal endBirthYear = seasonId - division.MinimumAge.Value;

                    var regMember = await ctx.BMemberRegistration
                        //.Where(s => s.SeasonId == seasonId)
                        .Where(s => s.DivisionId == divisionId && s.SeasonId == seasonId)
                        .Select(s => s.MemberId).ToArrayAsync();


                    contentList = await ctx.BMember
                        .Where (s=>s.DateOfBirth.Value.Year >= startBirthYear && s.DateOfBirth.Value.Year <= endBirthYear)
                        //.Where(s => regMember.Contains(s.MemberId))
                        .Select(s => new MemberProspectModel
                        {
                            MemberId = s.MemberId,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            DateOfBirth = s.DateOfBirth.Value
                        }).ToListAsync();



                }
            }
            return contentList.OrderBy(s=>s.FirstName).ToList();
        }


        public async Task<TeamModel> GetTeamById(int teamId, IMapper _mapper)
        {
            TeamModel content = new TeamModel();
            using (var ctx = new PBAContext())
            {
                var data = await ctx.BTeam
                    .Include(s => s.BTeamPlayers)
                    .Include(s => s.BTeamOfficial)
                    .Include(s => s.Division)
                    .Where(s => s.TeamId == teamId)
                    .Select(s => s).FirstOrDefaultAsync();
                content = SetTeamData(data, _mapper, ctx);


            }
            return content;
        }

        static TeamModel SetTeamData(BTeam src, IMapper _mapper, PBAContext ctx)
        {
            TeamModel data = new TeamModel();
            data = _mapper.Map<TeamModel>(src);

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

                data.Officials = new List<TeamOfficialModel>();

                foreach (var t in src.BTeamOfficial)
                {
                    TeamOfficialModel p = new TeamOfficialModel();
                    p.OfficialId= t.OfficialId;
                    p.TeamOfficialId = t.TeamOfficialId;
                    
                    var official = ctx.BOfficial.Single(s => s.OfficialId== t.OfficialId);
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



        public async Task<List<PositionModel>> GetPositionList()
        {
            List<PositionModel> PositionList= new List<PositionModel>();
            using (var ctx = new PBAContext())
            {

                PositionList = await ctx.BPosition
                    .Where(s=>s.PositionTypeId==3)
                    .Select(s => new PositionModel {
                        PositionId = s.PositionId,
                        PositionName = s.PositionName
                    } ).ToListAsync();
                

            }
            return PositionList;
        }

        public async Task<List<PositionModel>> GetAllPositionList()
        {
            List<PositionModel> PositionList = new List<PositionModel>();
            using (var ctx = new PBAContext())
            {

                PositionList = await ctx.BPosition
                    .Select(s => new PositionModel
                    {
                        PositionId = s.PositionId,
                        PositionName = s.PositionName
                    }).ToListAsync();


            }
            return PositionList;
        }

        public async Task<int> SaveTeam(TeamModel model)
        {
            int TeamId = 0;
            try
            {

                using (var ctx = new PBAContext())
                {
                    string TeamName = model.DivisionName;
                    if (model.Officials.Count > 0)
                    {
                        foreach(var x in model.Officials)
                        {
                            TeamName += '-' + x.FirstName + ' ' + x.LastName;
                            break;
                        }
                    }
                    

                    var team = await (from p in ctx.BTeam
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
                        t.MinAge =  1;
                        t.MaxAge = 50;
                        t.IsPibnateam = true;;
                        t.IsCompetitive = true;;
                        ctx.BTeam.Add(t);
                        ctx.SaveChanges();
                        model.TeamId = t.TeamId;
                    }
                    else
                    {
                        team.AssociationId= model.AssociationId;
                        team.DivisionId = model.DivisionId;
                        team.SeasonId = model.SeasonId;
                        team.TeamName = model.TeamName;
                        team.CreatedUserId = model.CreatedUserId;
                        team.IsCompetitive = model.IsCompetitive;
                        team.IsPibnateam = model.IsPibnateam;
                        team.DateUpdated= DateTime.Now;
                        ctx.SaveChanges();

                    }

                    TeamId = model.TeamId;

                    //Remove existing official
                    var xOfficial = ctx.BTeamOfficial.Where(x => x.TeamId == model.TeamId);
                    ctx.BTeamOfficial.RemoveRange(xOfficial);
                    

                    foreach (var o in model.Officials)
                    {
                        var official = ctx.BTeamOfficial.Where(s => s.TeamOfficialId == o.TeamOfficialId).Select(s => s).FirstOrDefault();
                        if (official == null)
                        {
                            BTeamOfficial tOfficial = new BTeamOfficial();
                            tOfficial.TeamId = model.TeamId;
                            tOfficial.OfficialId= o.OfficialId;
                            ctx.BTeamOfficial.Add(tOfficial);
                        }
                    }
                    ctx.SaveChanges();



                    //Check if the Member is remove on the current list
                    var cRoster = await(ctx.BTeamPlayers.Where(s => s.TeamId == model.TeamId).Select(p => p)).ToListAsync();
                    foreach (var r in cRoster)
                    {
                        var isExist = model.Rosters.Where(s => s.TeamPlayerId== r.TeamPlayerId).Select(s => s).FirstOrDefault();
                        if (isExist == null)
                        {
                            ctx.BTeamPlayers.Remove(r);
                        }
                    }
                    ctx.SaveChanges();

                    var NewRoster = model.Rosters.Where(s => s.TeamPlayerId== 0).Select(s => s).ToList();

                    foreach (var r in NewRoster)
                    {
                       
                        if (r.TeamPlayerId <= 0)
                        {
                            BTeamPlayers roster = new BTeamPlayers();
                            roster.TeamId = model.TeamId;
                            roster.MemberId = r.MemberId;
                            roster.DateJoined = DateTime.Now;
                            ctx.BTeamPlayers.Add(roster);
                        }
                    }
                    ctx.SaveChanges();




                }
            }
            catch (Exception err)
            {
                string emsg = err.Message;
            }
            return TeamId;
        }


    }
}