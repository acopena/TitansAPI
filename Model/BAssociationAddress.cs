using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BAssociationAddress
    {
        public int AssociationAddressId { get; set; }
        public string AssociationStreetNo { get; set; }
        public string AssociationStreetName { get; set; }
        public string AssociationStreetType { get; set; }
        public string AssociationCity { get; set; }
        public string AssociationProvince { get; set; }
        public string AssociationCountry { get; set; }
        public string AssociationPostalCode { get; set; }
        public int? AssociationId { get; set; }
        public int? AddressTypeId { get; set; }

        public BAddressType AddressType { get; set; }
        public BAssociation Association { get; set; }
    }
}
