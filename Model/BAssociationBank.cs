using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BAssociationBank
    {
        public int BankAccountId { get; set; }
        public int AssociationId { get; set; }
        public string BankAccountNo { get; set; }
        public string BankAccountName { get; set; }
        public bool? BankAccountStatus { get; set; }
        public string BankName { get; set; }
        public string BankContactPerson { get; set; }
        public string BankContactEmail { get; set; }
        public string BankContactPhone { get; set; }

        public virtual BAssociation Association { get; set; }
    }
}
