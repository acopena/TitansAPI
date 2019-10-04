using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BServicesType
    {
        public BServicesType()
        {
            BServicesFee = new HashSet<BServicesFee>();
        }

        public int ServicesTypeId { get; set; }
        public string ServicesTypeDesc { get; set; }

        public ICollection<BServicesFee> BServicesFee { get; set; }
    }
}
