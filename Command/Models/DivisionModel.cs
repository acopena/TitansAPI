using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Command.Models
{
    public class DivisionModel
    {
        public int DivisionId { get; set; }
        public int AssociationId { get; set; }
        public string DivisionName { get; set; }
        public decimal? MinimumAge { get; set; }
        public decimal? MaximumAge { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CreatedUserId { get; set; }
        public int? DivisionTypeId { get; set; }
       
    }
}
