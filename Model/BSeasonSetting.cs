using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BSeasonSetting
    {
        public int SeasonSettingId { get; set; }
        public int AssociationId { get; set; }
        public int SeasonId { get; set; }
        public DateTime? DivisionCutOfDate { get; set; }
    }
}
