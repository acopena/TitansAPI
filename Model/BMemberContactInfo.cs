using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BMemberContactInfo
    {
        public int MemberContactId { get; set; }
        public string MemberContactName { get; set; }
        public string MemberHomePhone { get; set; }
        public string MemberCellPhone { get; set; }
        public string MemberWorkPhone { get; set; }
        public string MemberEmail { get; set; }
        public int? ContactTypeId { get; set; }
        public int? MemberId { get; set; }
        public bool? PrimaryContact { get; set; }

        public BContactType ContactType { get; set; }
        public BMember Member { get; set; }
    }
}
