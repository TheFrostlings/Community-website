using System;
using System.Threading.Tasks;
using DSharpPlus;
using Newtonsoft.Json.Linq;

namespace FrostlingsBot
{
	class Program
	{
		private static DiscordClient discord;

		private static void Main(string[] args)
		{
			Config.Initialize(true);

			MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		private static async Task MainAsync(string[] args)
		{
			string token = Config.Get<string>("bot.client_secret", null);
			Console.WriteLine(token);
			discord = new DiscordClient(new DiscordConfiguration
			{
				Token     = token,
				TokenType = TokenType.Bot
			});
			
			discord.MessageCreated += async e =>
			{
				if (e.Message.Content.ToLower().StartsWith("ping"))
					await e.Message.RespondAsync("pong!");
			};
			
			await discord.ConnectAsync();
			await Task.Delay(-1);
		}
	}
}
