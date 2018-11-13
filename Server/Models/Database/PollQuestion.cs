using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class PollQuestion
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public long PollerId { get; set; }

		[Required]
		public string Question { get; set; }

		public bool     AllowMultipleAnswers { get; set; }
		public DateTime StartDate            { get; set; }
		public DateTime EndDate              { get; set; }


		// Relations
		public virtual DiscordUser Poller { get; set; }
	}
}
