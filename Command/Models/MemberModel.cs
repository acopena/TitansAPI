using System;
using System.Collections.Generic;
using System.Text;
using TitansAPI.Model;

namespace TitansAPI.Command.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public int UserId { get; set; }
        public string MemberNotes { get; set; }
        public string JerseyNo { get; set; }
        public int? StatusId { get; set; }
        public bool? BlockAccount { get; set; }
        public string Address { get; set; }

        public BAssociation Association { get; set; }
        public BRelationshipType Relationship { get; set; }
        public BStatus Status { get; set; }
        public BUsers User { get; set; }
        public ICollection<BJersey> BJersey { get; set; }
        public ICollection<BMemberContactInfo> BMemberContactInfo { get; set; }
        public ICollection<BMemberEmergencyContact> BMemberEmergencyContact { get; set; }
        public ICollection<BMemberRegistration> BMemberRegistration { get; set; }
        public ICollection<BMemberaddress> BMemberaddress { get; set; }
        public ICollection<BPicture> BPicture { get; set; }
        public ICollection<BTeamPlayers> BTeamPlayers { get; set; }
    }

    public class MemberUrlModel
    {
        public int MemberId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int BirthYear { get; set; }
        public int BirthMonth { get; set; }
        public int BirthDay { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }
        public string MemberNotes { get; set; }
        public string JerseyNo { get; set; }
        public string Address { get; set; }
        public List<ContactInfoModel> ContactInfo{ get; set; }
        public EmergencyInfoModel EmergencyInfo { get; set; }

    }

    public class ContactInfoModel
    {
        public int memberContactId{ get; set; }
        public string memberContactName { get; set; }
        public string contactTypeID { get; set; }
        public string memberEmail { get; set; }
        public string memberHomePhone { get; set; }
        public string memberCellPhone { get; set; }
        public bool primaryContact { get; set; }
    }

    public class EmergencyInfoModel
    {
        public int emergencyContactId{ get; set; }
        public string emergencyContactName { get; set; }
        public string emergencyContactNo { get; set; }
        public string emergencyAddress { get; set; }
        public string emergencyRelationShip { get; set; }
        
    }

 
}
