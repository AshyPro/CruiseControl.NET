using System;
using System.Collections;
using System.Text;
using tw.ccnet.core;

namespace tw.ccnet.web
{
	public class LogStatistics
	{
		public static LogStatistics Create(string path)
		{
			return new LogStatistics(LogFile.GetLogFileNames(path));
		}

		private string[] _logfiles;

		public LogStatistics(string[] logfiles)
		{
			_logfiles = logfiles;
			ArrayList.Adapter(_logfiles).Sort();
		}

		public string[] LogFilenames
		{
			get { return _logfiles; }
		}

		public int GetTotalSuccessfulBuilds()
		{
			int count = 0;
			foreach (string logfile in _logfiles)
			{
				if (LogFile.IsSuccessful(logfile))
				{
					count++;
				}
			}
			return count;
		}

		public int GetTotalFailedBuilds()
		{
			return _logfiles.Length - GetTotalSuccessfulBuilds();
		}

		public double GetSuccessRatio()
		{
			if (_logfiles.Length == 0)
			{
				return 0;
			}
			return (double)GetTotalSuccessfulBuilds() / (double)_logfiles.Length;
		}

		public string GetLatestLogFile()
		{
			if (_logfiles.Length == 0)
			{
				return null;
			}
			return _logfiles[_logfiles.Length-1];
		}

		public bool IsLatestBuildSuccessful()
		{
			if (_logfiles.Length == 0)
			{
				return false;
			}
			return LogFile.IsSuccessful(GetLatestLogFile());
		}

		public TimeSpan GetTimeSinceLatestBuild()
		{
			if (_logfiles.Length == 0)
			{
				return new TimeSpan(0);
			}
			DateTime date = LogFile.ParseForDate(LogFile.ParseForDateString(GetLatestLogFile()));
			return DateTime.Now - date;
		}

		public string GetTimeSinceLatestBuildString()
		{
			TimeSpan interval = GetTimeSinceLatestBuild();

			StringBuilder buffer = new StringBuilder();
			if (interval.Days > 0)
			{
				buffer.Append(interval.Days).Append(" days, ");
			}
			if (interval.Hours > 0)
			{
				buffer.Append(interval.Hours).Append(" hours and ");
			}
			buffer.Append(interval.Minutes).Append(" minutes");
			return buffer.ToString();
		}
	}
}
