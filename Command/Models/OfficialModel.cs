using System;
using System.Collections.Generic;
using System.Text;

namespace TitansAPI.Command.Models
{
    public class OfficialModel
    {
        public int OfficialId{ get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string EmailAddress{ get; set; }
        public string CellPhone{ get; set; }
        public int PositionId{ get; set; }
        public string PositionName{ get; set; }
        public int OfficialStatusId { get; set; }
    }
}
