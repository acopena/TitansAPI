using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BGymInfo
    {
        public int GymId { get; set; }
        public string GymAddress { get; set; }
        public decimal GymLatitude { get; set; }
        public decimal GymLangtitude { get; set; }
        public string GymNotes { get; set; }
        public string GymName { get; set; }
        public int? SeasonId { get; set; }
    }
}
