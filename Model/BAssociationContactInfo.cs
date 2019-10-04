using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BAssociationContactInfo
    {
        public int AssociationContactId { get; set; }
        public string AssociationContactName { get; set; }
        public string AssociationHomePhone { get; set; }
        public string AssociationCellPhone { get; set; }
        public string AssociationWorkPhone { get; set; }
        public string AssociationWorkPhoneExt { get; set; }
        public string AssociationFaxNo { get; set; }
        public string AssociationEmail { get; set; }
        public int? AssociationContactTypeId { get; set; }
        public int? AssociationId { get; set; }
        public int? ContactTypeId { get; set; }

        public BAssociation Association { get; set; }
        public BContactType ContactType { get; set; }
    }
}
