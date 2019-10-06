using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BServicesFee
    {
        public BServicesFee()
        {
            BMemberServiceFee = new HashSet<BMemberServiceFee>();
            BTeam = new HashSet<BTeam>();
        }

        public int ServicesFeeId { get; set; }
        public string AccountNo { get; set; }
        public int SeasonId { get; set; }
        public decimal Amount { get; set; }
        public int AssociationId { get; set; }
        public int? DivisionId { get; set; }
        public int? ServicesTypeId { get; set; }

        public virtual BCoa AccountNoNavigation { get; set; }
        public virtual BDivision Division { get; set; }
        public virtual BServicesType ServicesType { get; set; }
        public virtual ICollection<BMemberServiceFee> BMemberServiceFee { get; set; }
        public virtual ICollection<BTeam> BTeam { get; set; }
    }
}
