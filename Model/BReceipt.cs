using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BReceipt
    {
        public int ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal ReceiptAmount { get; set; }
        public int PaymentTypeId { get; set; }
        public Guid CartGuid { get; set; }
        public int? PostedById { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool ReceiptStatus { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? Ordate { get; set; }
        public string Orno { get; set; }
        public string Ornotes { get; set; }
        public decimal Oramount { get; set; }

        public BCart CartGu { get; set; }
        public BPaymentType PaymentType { get; set; }
    }
}
