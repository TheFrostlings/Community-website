using System;
using System.Collections.Generic;
using Server.Models;
using Server.Models.Database;

namespace Server.Seeds.Release
{
	public static class SocialPlatformSeeder
	{
		public static void Seed(DatabaseContext context, bool debug = false)
		{
			StartSeeding();
			
			List<SocialPlatform> platforms = new List<SocialPlatform>
			{
				new SocialPlatform
				{
					Name = "Steam",
					Icon = "fa-steam"
				},
				new SocialPlatform
				{
					Name = "Origin",
				},
				new SocialPlatform
				{
					Name = "Battle.net",
				},
				new SocialPlatform
				{
					Name = "Twitch",
					Icon = "fa-twitch"
				},
				new SocialPlatform
				{
					Name = "uPlay",
				},
				new SocialPlatform
				{
					Name = "Playstation Network",
					Icon = "fa-playstation "
				},
				new SocialPlatform
				{
					Name = "Xbox",
					Icon = "fa-xbox"
				},
				new SocialPlatform
				{
					Name = "Twitter",
					Icon = "fa-twitter"
				}
			};

			context.AddRange(platforms);
			context.SaveChanges();
			
			EndSeeding();
		}
		
		private static void StartSeeding()
		{
			Console.WriteLine("Start seeding " +typeof(SocialPlatform).Name);
		}
		
		private static void EndSeeding()
		{
			Console.WriteLine("End seeding " +typeof(SocialPlatform).Name);
		}
	}
}
