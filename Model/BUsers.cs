using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BUsers
    {
        public BUsers()
        {
            BCart = new HashSet<BCart>();
            BClinicstaff = new HashSet<BClinicstaff>();
            BCoachSchedule = new HashSet<BCoachSchedule>();
            BMember = new HashSet<BMember>();
            BMemberRegistration = new HashSet<BMemberRegistration>();
            BTeamDiscussion = new HashSet<BTeamDiscussion>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int? AssociationId { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string WorkPhoneExt { get; set; }
        public string StreetNo { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int UserTypeId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public byte[] Photo { get; set; }
        public string AccessCode { get; set; }
        public string CellPhone { get; set; }
        public bool? BlockAccount { get; set; }

        public BAssociation Association { get; set; }
        public BUserType UserType { get; set; }
        public ICollection<BCart> BCart { get; set; }
        public ICollection<BClinicstaff> BClinicstaff { get; set; }
        public ICollection<BCoachSchedule> BCoachSchedule { get; set; }
        public ICollection<BMember> BMember { get; set; }
        public ICollection<BMemberRegistration> BMemberRegistration { get; set; }
        public ICollection<BTeamDiscussion> BTeamDiscussion { get; set; }
    }
}
