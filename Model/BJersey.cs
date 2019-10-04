using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BJersey
    {
        public int JerseyId { get; set; }
        public int MemberId { get; set; }
        public bool? OrderJersey { get; set; }
        public int? JerseyPreparedNo { get; set; }
        public bool? StatusPayment { get; set; }
        public decimal? JerseyFee { get; set; }
        public int? SeasonId { get; set; }
    }
}
