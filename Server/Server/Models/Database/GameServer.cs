using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Database
{
	public enum GameServerType
	{
		Public,
		Private
	}

	public class GameServer
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public long GameId { get; set; }

		[Required]
		public long OwnerId { get; set; }

		[Required]
		public string Name { get; set; }

		public string         Summary { get; set; }
		public string         Ip      { get; set; }
		public GameServerType Type    { get; set; }


		// Relations
		public virtual Game        Game { get; set; }
		public virtual DiscordUser User { get; set; }
	}
}
