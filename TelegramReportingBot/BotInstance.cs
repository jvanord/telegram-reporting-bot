using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramReportingBot {
	internal class BotInstance {
		private string _token;
		private Logger _logger;

		BotInstance(string token, Logger logger) {
			_token = token;
			_logger = logger; 
		}

		internal async void StartPolling() {
			using var cts = new CancellationTokenSource();
			var client = new TelegramBotClient(_token, cancellationToken: cts.Token);
			var botIdentity = await client.GetMeAsync();
			await client.DropPendingUpdatesAsync();
			client.OnMessage += async (message, updateType) => {
				await Task.Delay(1000);
			};
			client.OnUpdate += async (update) => {
				await Task.Delay(1000);
			};
			client.OnError += (exception, source) => {
				throw exception;
			};
		}
	}
}
