using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class Event
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public long OrganizerId { get; set; }

		[Required]
		public long TypeId { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Summary { get; set; }

		[Required]
		public string Location { get; set; }


		// Relations
		public virtual DiscordUser Organizer { get; set; }
		public virtual EventType   Type      { get; set; }
	}
}
