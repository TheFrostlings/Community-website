using Microsoft.EntityFrameworkCore;
using Server.Models.Database;

namespace Server.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<DiscordUser>    DiscordUsers    { get; set; }
		public DbSet<Event>          Events          { get; set; }
		public DbSet<EventType>      EventTypes      { get; set; }
		public DbSet<Game>           Games           { get; set; }
		public DbSet<GameServer>     GameServers     { get; set; }
		public DbSet<GiveAwayKey>    GiveAwayKeys    { get; set; }
		public DbSet<PollAnswer>     PollAnswers     { get; set; }
		public DbSet<PollQuestion>   PollQuestions   { get; set; }
		public DbSet<PollVote>       PollVotes       { get; set; }
		public DbSet<SocialPlatform> SocialPlatforms { get; set; }
		public DbSet<UserProfile>    UserProfiles    { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("frostlings");

			modelBuilder.Entity<PollVote>().HasKey("AnswerId", "VoterId");

			modelBuilder.Entity<DiscordUser>()
			            .HasMany(u => u.GiveAwayKeyAcquirers)
			            .WithOne(g => g.AcquiredBy);

			modelBuilder.Entity<DiscordUser>()
			            .HasMany(u => u.GiveAwayKeySuppliers)
			            .WithOne(g => g.SuppliedBy);
		}
	}
}
