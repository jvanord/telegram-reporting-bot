// See https://aka.ms/new-console-template for more information
using Telegram.Bot;
using TelegramReportingBot;

Console.WriteLine("Hello, World!");

string botToken = string.Empty;
string logLocation = string.Empty;
bool includeFiles = false;

for (int i = 0; i < args.Length; i++) {
	switch (args[i]) {
		case "--token":
		case "-t":
			i++;
			if (i >= args.Length) throw new ArgumentException("No value argument profided for ''" + args[i-1] + "''");
			botToken = args[i];
			break;
		case "--logs":
		case "-l":
			i++;
			if (i >= args.Length) throw new ArgumentException("No value argument profided for '" + args[i-1] + "'");
			logLocation = args[i];
			break;
		case "--files":
		case "-f":
			includeFiles = true;
			break;
		default: throw new ArgumentException("Unexpected argument '" + args[i] + "'");	
	}
}
if (string.IsNullOrEmpty(botToken)) throw new ArgumentException("Argument 'token' must be specified.");
if (string.IsNullOrEmpty(logLocation)) logLocation = @"./logs";

var logger = new Logger(logLocation, includeFiles);
Console.WriteLine($"Reported message data will be saved to: '{logger.GetLogFilePath()}'");
if (includeFiles)
	Console.WriteLine($"Media will be saved to: '{logger.GetMediaFolderPath()}'");

