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

        public BCoa AccountNoNavigation { get; set; }
        public BDivision Division { get; set; }
        public BServicesType ServicesType { get; set; }
        public ICollection<BMemberServiceFee> BMemberServiceFee { get; set; }
        public ICollection<BTeam> BTeam { get; set; }
    }
}
