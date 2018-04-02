using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class UserProfile
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public long UserId { get; set; }

		[Required]
		public long PlatformId { get; set; }

		[Required]
		public string Username { get; set; }

		public string Url { get; set; }

		// Relations
		public virtual DiscordUser    User     { get; set; }
		public virtual SocialPlatform Platform { get; set; }
	}
}
