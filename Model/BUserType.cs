using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BUserType
    {
        public BUserType()
        {
            BUsers = new HashSet<BUsers>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        public virtual ICollection<BUsers> BUsers { get; set; }
    }
}
