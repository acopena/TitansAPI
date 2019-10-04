using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BTvMenu
    {
        public int TvMenuId { get; set; }
        public string TvMenuDescription { get; set; }
        public string TvMenuNodeUrl { get; set; }
        public int? TvMenuNodeType { get; set; }
        public int? TvMenuGroupId { get; set; }
        public int? SortOrder { get; set; }
        public int? ParentId { get; set; }
        public decimal? MenuOrderGroup { get; set; }
    }
}
