using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;
using Server.Models.Database;

namespace Server.Seeds.Debug
{
	public static class DiscordUserSeeder
	{
		public static void Seed(DatabaseContext context, bool debug = false)
		{
			if( !debug ) return;
			
			StartSeeding();

			List<DiscordUser> users = new List<DiscordUser>
			{
				new DiscordUser
				{
					Username   = "TheCryosGurl",
					DiscordTag = "#2906",
					DiscordUid = "139771987231899648",
					Profiles = new List<UserProfile>()
					{
						new UserProfile()
						{
							PlatformId = context.SocialPlatforms.First(p => p.Name == "Twitch").Id,
							Username = "TheCryosGurl",
							Url = "https://www.twitch.tv/thecryosgurl"
						},
						new UserProfile()
						{
							PlatformId = context.SocialPlatforms.First(p => p.Name == "Steam").Id,
							Username   = "TheCryosGurl"
						}
					}
				},
				new DiscordUser
				{
					Username   = "TheWoman",
					DiscordTag = "#9873",
					DiscordUid = "124162382380531712"
				},
				new DiscordUser
				{
					Username   = "Peter",
					DiscordTag = "#5245",
					DiscordUid = "227919168328957953"
				},
				new DiscordUser
				{
					Username   = "Codex404 (Stefan)",
					DiscordTag = "#2564",
					DiscordUid = "134760450012348416",
					Profiles = new List<UserProfile>()
					{
						new UserProfile()
						{
							PlatformId = context.SocialPlatforms.First(p => p.Name == "Steam").Id,
							Username   = "stefannafest_1995"
						}
					}
				},
				new DiscordUser
				{
					Username   = "koen1804",
					DiscordTag = "#5631",
					DiscordUid = "95239613727125504"
				},
				new DiscordUser
				{
					Username   = "welldooder64",
					DiscordTag = "#8766",
					DiscordUid = "83265445456515072"
				},
				new DiscordUser
				{
					Username   = "tjeerddie",
					DiscordTag = "#0435",
					DiscordUid = "145854644839514112"
				},
			};

			context.AddRange(users);
			context.SaveChanges();

			EndSeeding();
		}

		private static void StartSeeding()
		{
			Console.WriteLine("Start seeding " + typeof(DiscordUser).Name);
		}

		private static void EndSeeding()
		{
			Console.WriteLine("End seeding " + typeof(DiscordUser).Name);
		}
	}
}
