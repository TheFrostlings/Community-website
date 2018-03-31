using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Server.Models;
using Server.Seeds.Debug;
using Server.Seeds.Release;

namespace Server.Controllers.Database
{
	public static class Seeder
	{
		public static void Seed(IServiceProvider serviceProvider, bool debug=false)
		{
			using( IServiceScope serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope() )
			{
				DatabaseContext context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

				if( context.SocialPlatforms.Any() )
				{
					Console.WriteLine("No seeding needed, already filled with data");
					return;
				}
				
				
				//SocialPlatformSeeder.Seed(context, debug);
				//DiscordUserSeeder.Seed(context, debug);
			}
		}
	}
}
