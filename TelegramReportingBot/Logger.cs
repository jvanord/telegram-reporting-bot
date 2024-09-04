using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramReportingBot {
	internal class Logger {

		private string _rootLocation;
		private FileInfo _logFile;
		private DirectoryInfo? _mediaDirectory;

		internal Logger(string rootLocation, bool includeFiles = false) {
			_rootLocation = rootLocation;
			if (string.IsNullOrWhiteSpace(rootLocation)) throw new ArgumentNullException(nameof(rootLocation));
			var info = new DirectoryInfo(rootLocation);
			if (!info.Exists) info.Create();
			_logFile = GetNewLogFile();
			if (includeFiles) {
				_mediaDirectory = new DirectoryInfo(Path.Combine(_rootLocation, "media", _logFile.Name));
				if (!_mediaDirectory.Exists) _mediaDirectory.Create();
			}
		}

		internal string GetLogFilePath() { return _logFile.FullName; }
		internal string GetMediaFolderPath() { return _mediaDirectory?.FullName ?? string.Empty; }

		private FileInfo GetNewLogFile() {
			return new FileInfo(Path.Combine(_rootLocation, DateTime.Now.ToString("s") + ".dat"));
		}

		private void ResetLocations() {
			var stamp = DateTime.Now.ToString("s");
			_logFile = new FileInfo(Path.Combine(_rootLocation, stamp + ".dat"));
		}
	}
}
