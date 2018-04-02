using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class GiveAwayKey
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public string Key { get; set; }

		[Required]
		public long GameId { get; set; }

		[Required]
		public long PlatformId { get; set; }

		[Required]
		public long SuppliedById { get; set; }

		public long AcquiredById { get; set; }

		// Relations
		public virtual SocialPlatform Platform   { get; set; }
		public virtual DiscordUser    SuppliedBy { get; set; }
		public virtual DiscordUser    AcquiredBy { get; set; }
		public virtual Game           Game       { get; set; }
	}
}
