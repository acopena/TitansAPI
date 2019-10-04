using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BCoa
    {
        public BCoa()
        {
            BServicesFee = new HashSet<BServicesFee>();
        }

        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public int AccountTypeId { get; set; }

        public BAccountType AccountType { get; set; }
        public ICollection<BServicesFee> BServicesFee { get; set; }
    }
}
