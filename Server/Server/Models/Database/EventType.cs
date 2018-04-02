using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
    public class EventType
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        // Relations
        public virtual ICollection<Event> Events { get; set; }
    }
}