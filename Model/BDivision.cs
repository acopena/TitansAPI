using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BDivision
    {
        public BDivision()
        {
            BMemberRegistration = new HashSet<BMemberRegistration>();
            BServicesFee = new HashSet<BServicesFee>();
            BTeam = new HashSet<BTeam>();
        }

        public int DivisionId { get; set; }
        public int AssociationId { get; set; }
        public string DivisionName { get; set; }
        public decimal? MinimumAge { get; set; }
        public decimal? MaximumAge { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CreatedUserId { get; set; }
        public int? DivisionTypeId { get; set; }
        public string AccountNo { get; set; }
        public string GenderId { get; set; }

        public virtual ICollection<BMemberRegistration> BMemberRegistration { get; set; }
        public virtual ICollection<BServicesFee> BServicesFee { get; set; }
        public virtual ICollection<BTeam> BTeam { get; set; }
    }
}
