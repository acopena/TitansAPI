using System;
using System.Collections.Generic;

namespace TitansAPI.Model
{
    public partial class BEvents
    {
        public BEvents()
        {
            BEventAddress = new HashSet<BEventAddress>();
            BEventDivision = new HashSet<BEventDivision>();
            BEventTeams = new HashSet<BEventTeams>();
            BLeagueSchedule = new HashSet<BLeagueSchedule>();
        }

        public int EventNo { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public int AssociationId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PostedById { get; set; }
        public string EventHost { get; set; }
        public string EventContactName { get; set; }
        public string EventContactEmail { get; set; }
        public string EventContactNo { get; set; }
        public string EventPosition { get; set; }
        public string PostEventMemo { get; set; }
        public string PreEventMemo { get; set; }
        public int? SeasonId { get; set; }
        public int? EventType { get; set; }
        public string EventGymName { get; set; }
        public string EventAddress { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }
        public DateTime? EventConfirmationLastDate { get; set; }
        public decimal? EventCost { get; set; }

        public virtual BAssociation Association { get; set; }
        public virtual BEventType EventTypeNavigation { get; set; }
        public virtual ICollection<BEventAddress> BEventAddress { get; set; }
        public virtual ICollection<BEventDivision> BEventDivision { get; set; }
        public virtual ICollection<BEventTeams> BEventTeams { get; set; }
        public virtual ICollection<BLeagueSchedule> BLeagueSchedule { get; set; }
    }
}
