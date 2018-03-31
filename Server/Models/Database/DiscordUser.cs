using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class DiscordUser
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string DiscordTag { get; set; }

		[Required]
		public string DiscordUid { get; set; }

		public string Summary { get; set; }

		// Relations
		public virtual ICollection<UserProfile>  Profiles             { get; set; }
		public virtual ICollection<PollQuestion> PollQuestions        { get; set; }
		public virtual ICollection<PollVote>     PollVotes            { get; set; }
		public virtual ICollection<Event>        Events               { get; set; }
		public virtual ICollection<GiveAwayKey>  GiveAwayKeySuppliers { get; set; }
		public virtual ICollection<GiveAwayKey>  GiveAwayKeyAcquirers { get; set; }
	}
}
