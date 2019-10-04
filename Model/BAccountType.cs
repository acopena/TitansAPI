using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BAccountType
    {
        public BAccountType()
        {
            BCoa = new HashSet<BCoa>();
        }

        public int AccountTypeId { get; set; }
        public string AccountTypeDesc { get; set; }

        public ICollection<BCoa> BCoa { get; set; }
    }
}
