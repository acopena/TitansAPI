using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMember
    {
        public BMember()
        {
            BClinicMember = new HashSet<BClinicMember>();
            BMemberContactInfo = new HashSet<BMemberContactInfo>();
            BMemberEmergencyContact = new HashSet<BMemberEmergencyContact>();
            BMemberRegistration = new HashSet<BMemberRegistration>();
            BTeamPlayers = new HashSet<BTeamPlayers>();
        }

        public int MemberId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public int? AssociationId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string MemberHealthCardNo { get; set; }
        public string MemberNotes { get; set; }
        public bool? WithJersey { get; set; }
        public string JerseyNo { get; set; }
        public int? StatusId { get; set; }
        public bool? BlockAccount { get; set; }
        public string Address { get; set; }

        public BAssociation Association { get; set; }
        public BStatus Status { get; set; }
        public BUsers User { get; set; }
        public ICollection<BClinicMember> BClinicMember { get; set; }
        public ICollection<BMemberContactInfo> BMemberContactInfo { get; set; }
        public ICollection<BMemberEmergencyContact> BMemberEmergencyContact { get; set; }
        public ICollection<BMemberRegistration> BMemberRegistration { get; set; }
        public ICollection<BTeamPlayers> BTeamPlayers { get; set; }
    }
}
