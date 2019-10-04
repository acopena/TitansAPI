using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BAssociationProfile
    {
        public int AssociationId { get; set; }
        public bool? OtherInfomration { get; set; }
        public bool? Address { get; set; }
        public bool? ContactInformation { get; set; }
        public bool? EmergencyContact { get; set; }
        public bool? UploadImage { get; set; }

        public BAssociation Association { get; set; }
    }
}
