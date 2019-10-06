using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMemberEmergencyContact
    {
        public int EmergencyContactId { get; set; }
        public int MemberId { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNo { get; set; }
        public string EmergencyAddress { get; set; }
        public string EmergencyRelationShip { get; set; }

        public virtual BMember Member { get; set; }
    }
}
