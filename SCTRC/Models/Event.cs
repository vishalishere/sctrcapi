namespace SCTRC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Group { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }

        public virtual IEnumerable<Activity> Activities { get; set; }
        public virtual IEnumerable<Team> Teams { get; set; }
        public virtual ApplicationUser Admin { get; set; }
    }
}
