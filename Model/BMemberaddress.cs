using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMemberaddress
    {
        public int MemberAddressId { get; set; }
        public string MemberStreetNo { get; set; }
        public string MemberStreetName { get; set; }
        public string MemberStreetType { get; set; }
        public string MemberCity { get; set; }
        public string MemberProvince { get; set; }
        public string MemberCountry { get; set; }
        public string MemberPostalCode { get; set; }
        public int? MemberId { get; set; }
        public int? AddressTypeId { get; set; }
        public DateTime? MemberDateCreated { get; set; }
        public DateTime? MemberDateUpdated { get; set; }
        public int? MemberCreateUserId { get; set; }
        public int? MemberUpdateUserId { get; set; }

        public virtual BAddressType AddressType { get; set; }
    }
}
