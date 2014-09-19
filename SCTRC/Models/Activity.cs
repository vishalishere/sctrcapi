namespace SCTRC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    
        
        //Should it be different kind of users regarding the user being on a activty/event??
        public virtual IEnumerable<ApplicationUser> Users { get; set; }
    }
}
