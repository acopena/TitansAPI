using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BContactUs
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string SentTo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}
