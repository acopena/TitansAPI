using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BOrfile
    {
        public BOrfile()
        {
            BOrtrx = new HashSet<BOrtrx>();
        }

        public string Orno { get; set; }
        public DateTime Ordate { get; set; }
        public string PayeeName { get; set; }
        public int PaymentTypeId { get; set; }
        public int OrapplicationId { get; set; }
        public decimal Oramount { get; set; }
        public DateTime? DatePosted { get; set; }
        public int PostedById { get; set; }
        public int SeasonId { get; set; }
        public int AssociationId { get; set; }

        public virtual ICollection<BOrtrx> BOrtrx { get; set; }
    }
}
