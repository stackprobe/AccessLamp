using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AccessLamp
{
	// 複数のセッションで同時に実行したとき取り合いになるけど、catch してるし、まあいいや。

	public static class LogTools
	{
		private static string LogFile = Path.Combine(Environment.GetEnvironmentVariable("TMP"), "{019a7bcb-bb02-4669-a53f-f0f09cb50575}.log");
		private static string LogFile0 = LogFile + "0";

		public static void Clear()
		{
			try
			{
				File.Delete(LogFile);
				File.Delete(LogFile0);
			}
			catch
			{ }
		}

		private static long WriteCount;

		public static void Write(object message)
		{
			try
			{
				if (++WriteCount % 1000 == 0)
				{
					File.Delete(LogFile0);
					File.Move(LogFile, LogFile0);
				}
				using (StreamWriter writer = new StreamWriter(LogFile, true, Encoding.UTF8))
				{
					writer.WriteLine("[" + DateTime.Now + "] " + message);
				}
			}
			catch
			{ }
		}
	}
}
