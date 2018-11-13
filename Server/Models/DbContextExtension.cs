using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Server.Models.Database;

namespace Server.Models
{
	public static class DbContextExtension
	{
 
		public static bool AllMigrationsApplied(this DatabaseContext context)
		{
			return !context.Database.GetPendingMigrations().Any();
		}
		
		public static void EnsureSeeded(this DatabaseContext context)
		{
			context.SeedTable(context.SocialPlatforms);
			context.SeedTable(context.DiscordUsers);
			context.SeedTable(context.EventTypes);
			context.SeedTable(context.Games);
		}

		private static void SeedTable<T>(this DbContext context, IEnumerable<T> dbSet) where T : class
		{
			if( dbSet.Any() ) return;
			
			
			string name  = typeof(T).Name;
			string path  = "Seeds" + Path.DirectorySeparatorChar + name +".json";

			Console.WriteLine("SEEDING: "+name+" from path `"+path+"`");
			
			try
			{
				List<T> types = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
				context.AddRange(types);
				context.SaveChanges();
			}
			catch( FileNotFoundException e )
			{
				File.Create(path);
				Console.WriteLine("ERROR: Could not find file '" + path + "', created it for you.");
			}
			catch( Exception e )
			{
				Console.WriteLine(e);
			}
			
			
		}
	}
}