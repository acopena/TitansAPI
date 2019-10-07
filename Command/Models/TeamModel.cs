using System;
using System.Collections.Generic;
using System.Text;
using TitansAPI.Model;

namespace TitansAPI.Command.Models
{
    public class TeamTitansModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int? AssociationId { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionName{ get; set; }
        public int? SeasonId { get; set; }
        public bool? IsPibnateam { get; set; }
        public bool? IsCompetitive { get; set; }
        public int TotalRosters{ get; set; }
        public int CreatedUserId { get; set; }
        
        public ICollection<TeamTitansOfficialModel> Officials { get; set; }
        public ICollection<TeamPlayerModel> Rosters { get; set; }
    }

    public class TeamTitansOfficialModel
    {
        public int TeamOfficialId { get; set; }
        public int OfficialId { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public string CellPhone{ get; set; }
        public int positionId{ get; set; }
        public string positionName{ get; set; }

    }

    public class TeamPlayerModel
    {
        public int TeamPlayerId { get; set; }
        public int MemberId { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class PositionModel
    {
        public int PositionId{ get; set; }
        public string PositionName{ get; set; }
    }

    public class MemberProspectModel
    {
        public int MemberId{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public DateTime DateOfBirth{ get; set; }
    }




}
