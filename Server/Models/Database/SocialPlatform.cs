using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class SocialPlatform
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Icon  { get; set; }
		public long   Image { get; set; }

		// Relations
		public virtual ICollection<UserProfile> Profiles     { get; set; }
		public virtual ICollection<GiveAwayKey> GiveAwayKeys { get; set; }
	}
}
