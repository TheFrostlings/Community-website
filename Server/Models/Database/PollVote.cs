using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class PollVote
	{
		[Required]
		public long AnswerId { get; set; }

		[Required]
		public long VoterId { get; set; }


		// Relations
		public virtual DiscordUser Voter  { get; set; }
		public virtual PollAnswer  Answer { get; set; }
	}
}
