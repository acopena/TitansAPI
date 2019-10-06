using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{

    public class SearchEvent : ISearchEvent
    {

        public async Task<List<SearchModel>> GetList(string search)
        {
            List<SearchModel> list= new List<SearchModel>();
            using (var ctx = new titansContext())
            {
                var data = await ctx.BMember
                    .Include(s => s.BTeamPlayers)
                    .Include(s => s.BMemberContactInfo)
                    .Include(s => s.BMemberEmergencyContact)
                    .Where(s => s.FirstName.Contains(search) 
                        || s.LastName.Contains(search) 
                        || s.Address.Contains(search)
                    )
                    .Select(s => new SearchModel {
                        Id = s.MemberId,
                        Name = s.FirstName + " " + s.LastName,
                        Type = "Member",
                        Notes = s.DateOfBirth.ToString()
                    }).ToListAsync();

                list.AddRange(data);

                data = await ctx.BUsers
                   .Where(s => s.FirstName.Contains(search)
                       || s.LastName.Contains(search)
                       || s.UserName.Contains(search)
                   )
                   .Select(s => new SearchModel
                   {
                       Id = s.UserId,
                       Name = s.FirstName + " " + s.LastName,
                       Type = "User",
                       Notes = "UserName :" + s.UserName
                   }).ToListAsync();

                list.AddRange(data);

                data = await ctx.BTeam
                    .Include(s=>s.Division)
                   .Where(s => s.TeamName.Contains(search))
                   .Select(s => new SearchModel
                   {
                       Id = s.TeamId,
                       Name = s.TeamName,
                       Type = "Team",
                       Notes =  "Division:" +  s.Division.DivisionName + " | Season:" + s.SeasonId
                   }).ToListAsync();

                list.AddRange(data);

                data = await ctx.BTeamOfficial
                    .Include(s=>s.Official)
                 .Where(s => s.Official.OfficialFirstName.Contains(search) 
                 || s.Official.OfficialLastName.Contains(search)
                 || s.Official.EmailAddress.Contains(search))

                 .Select(s => new SearchModel
                 {
                     Id = s.TeamId,
                     Name = s.Official.OfficialFirstName + ' ' + s.Official.OfficialLastName,
                     Type = "Team",
                     Notes = "Position:" + s.Official.Position.PositionName + " | Email :" + s.Official.EmailAddress +  " | Team :" + s.Team.TeamName + " | Season:" + s.Team.SeasonId
                 }).ToListAsync();

                list.AddRange(data);
            }
            return list;
        }

        public async Task<List<MemberRegisteredModel>> GetRegisterMembers(int NoOfDays)
        {
            List<MemberRegisteredModel> list = new List<MemberRegisteredModel>();
            DateTime startDays = DateTime.Now.AddDays(NoOfDays * -1);
            using (var ctx = new titansContext())
            {
                var data = await ctx.BMemberRegistration
                    .Include(s => s.Member)
                    .Include(s => s.Member.BMemberContactInfo)
                    .Include(s => s.Member.BMemberEmergencyContact)
                    .Where(s =>  s.DateReg >= startDays)
                    .Select(s => new MemberRegisteredModel
                    {
                        MemberId = s.MemberId,
                        Name = s.Member.FirstName + " " + s.Member.LastName,
                        DateReg =  s.DateReg,
                        ContactEmail = s.Member.BMemberContactInfo.Where(r=>r.PrimaryContact.Value==true).FirstOrDefault().MemberEmail,
                        HomePhone = s.Member.BMemberContactInfo.Where(r => r.PrimaryContact.Value == true).FirstOrDefault().MemberHomePhone,
                        CellPhone = s.Member.BMemberContactInfo.Where(r => r.PrimaryContact.Value == true).FirstOrDefault().MemberCellPhone,
                        Age= DateTime.Now.Year - s.Member.DateOfBirth.Value.Year
                        
                    }).ToListAsync();

                list.AddRange(data);
            }
            return list;
        }

    }

    public class MemberRegisteredModel
    {
        public int MemberId{ get; set; }
        public string Name{ get; set; }
        public DateTime DateReg{ get; set; }
        public int RegDays { get; set; }
        public string ContactEmail{ get; set; }
        public string HomePhone{ get; set; }
        public string CellPhone { get; set; }
        public string DivisionName{ get; set; }
        public int Age{ get; set; }



    }
}
