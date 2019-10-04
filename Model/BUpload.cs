using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Model
{
    public partial class BUpload
    {
        public int UploadId { get; set; }
        public string Name{ get; set; }
        public string Type { get; set; }
        public string Description{ get; set; }
        public DateTime  FromDate  { get; set; }
        public DateTime? EndDate{ get; set; }
        public int SeasonId{ get; set; }
        public string ImagePath{ get; set; }
        public int? DivisionId { get; set; }
    }
}
