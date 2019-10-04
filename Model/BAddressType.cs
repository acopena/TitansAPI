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

        public ICollection<BAssociationAddress> BAssociationAddress { get; set; }
        public ICollection<BMemberaddress> BMemberaddress { get; set; }
    }
}
