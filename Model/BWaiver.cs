using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BWaiver
    {
        public BWaiver()
        {
            BMemberRegistration = new HashSet<BMemberRegistration>();
        }

        public int WaiverId { get; set; }
        public int AssociationId { get; set; }
        public string WaiverTitle { get; set; }
        public string WaiverBody { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<BMemberRegistration> BMemberRegistration { get; set; }
    }
}
