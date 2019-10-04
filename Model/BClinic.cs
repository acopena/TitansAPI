using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BClinic
    {
        public BClinic()
        {
            BClinicMember = new HashSet<BClinicMember>();
            BClinicOfficials = new HashSet<BClinicOfficials>();
            BClinicProgramTrx = new HashSet<BClinicProgramTrx>();
            BClinicSchedule = new HashSet<BClinicSchedule>();
        }

        public int ClinicId { get; set; }
        public string ClinicLocation { get; set; }
        public string ClinicStreet1 { get; set; }
        public string ClinicStreet2 { get; set; }
        public string ClinicCity { get; set; }
        public string ClinicPostalCode { get; set; }
        public string ClinicProvince { get; set; }
        public string ClinicCountry { get; set; }
        public int? SeasonId { get; set; }
        public int? ClinicCap { get; set; }
        public int? ClinicMinAge { get; set; }
        public int? ClinicMaxAge { get; set; }
        public string ClinicMemo { get; set; }
        public string ClinicName { get; set; }
        public int AssociationId { get; set; }
        public DateTime? ClinicStartDate { get; set; }
        public DateTime? ClinicEndDate { get; set; }

        public BAssociation Association { get; set; }
        public ICollection<BClinicMember> BClinicMember { get; set; }
        public ICollection<BClinicOfficials> BClinicOfficials { get; set; }
        public ICollection<BClinicProgramTrx> BClinicProgramTrx { get; set; }
        public ICollection<BClinicSchedule> BClinicSchedule { get; set; }
    }
}
