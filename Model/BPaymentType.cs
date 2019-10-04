using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BPaymentType
    {
        public BPaymentType()
        {
            BReceipt = new HashSet<BReceipt>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public ICollection<BReceipt> BReceipt { get; set; }
    }
}
