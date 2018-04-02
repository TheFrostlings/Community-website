using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
    public class Game
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string SteamId { get; set; }

        // Relations
        public virtual ICollection<GiveAwayKey> GiveAwayKeys { get; set; }
    }
}