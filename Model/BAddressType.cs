using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BAddressType
    {
        public BAddressType()
        {
            BAssociationAddress = new HashSet<BAssociationAddress>();
            BMemberaddress = new HashSet<BMemberaddress>();
        }

        public int AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }

        public virtual ICollection<BAssociationAddress> BAssociationAddress { get; set; }
        public virtual ICollection<BMemberaddress> BMemberaddress { get; set; }
    }
}
