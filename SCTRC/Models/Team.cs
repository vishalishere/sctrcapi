namespace SCTRC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string TeamName { get; set; }
        public string Contact { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
