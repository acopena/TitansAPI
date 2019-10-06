using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BOfficial
    {
        public BOfficial()
        {
            BTeamOfficial = new HashSet<BTeamOfficial>();
        }

        public int OfficialId { get; set; }
        public string OfficialFirstName { get; set; }
        public string OfficialLastName { get; set; }
        public DateTime? OfficialDateOfBirth { get; set; }
        public int PositionId { get; set; }
        public string EmailAddress { get; set; }
        public string TelNo { get; set; }
        public string CellPhone { get; set; }
        public string Notes { get; set; }
        public int AssociationId { get; set; }
        public int OfficialStatusId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public virtual BOfficialStatus OfficialStatus { get; set; }
        public virtual BPosition Position { get; set; }
        public virtual ICollection<BTeamOfficial> BTeamOfficial { get; set; }
    }
}
