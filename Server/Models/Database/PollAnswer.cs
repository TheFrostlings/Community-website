using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public class PollAnswer
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public long QuestionId { get; set; }

		[Required]
		public string Answer { get; set; }

		// Relations
		public virtual PollQuestion Question { get; set; }
	}
}
