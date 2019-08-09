using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace AccessLamp2
{
	public static class Gnd
	{
		public static EventWaitHandle Ev停止 = new EventWaitHandle(false, EventResetMode.AutoReset, "{724dbc96-8500-4758-adb2-dfcfbc6d8426}"); // shared_uuid

		public static string SelfFile;
		public static string SelfDir;

		public static string SettingFile;

		public static void Load(string file)
		{
			if (File.Exists(file) == false)
				return;

			string[] lines = File.ReadAllLines(file, Encoding.UTF8);
			int c = 0;

			try
			{
				MainWin_L = int.Parse(lines[c++]);
				MainWin_T = int.Parse(lines[c++]);
				MostTop = int.Parse(lines[c++]) != 0;
				PositionFixed = int.Parse(lines[c++]) != 0;
				BackgroundColor = (BackgroundColor_e)int.Parse(lines[c++]);
				// 新しい項目をここへ追加
			}
			catch
			{ }
		}

		public static void Save(string file)
		{
			List<string> lines = new List<string>();

			lines.Add("" + MainWin_L);
			lines.Add("" + MainWin_T);
			lines.Add("" + (MostTop ? 1 : 0));
			lines.Add("" + (PositionFixed ? 1 : 0));
			lines.Add("" + (int)BackgroundColor);
			// 新しい項目をここへ追加

			File.WriteAllLines(file, lines.ToArray(), Encoding.UTF8);
		}

		public static int MainWin_L = 0;
		public static int MainWin_T = 0;

		public static bool MostTop = true;
		public static bool PositionFixed = false;

		public enum BackgroundColor_e
		{
			Black = 1,
			DrakCyan,
			White,
		}

		public static BackgroundColor_e BackgroundColor = BackgroundColor_e.DrakCyan;
	}
}
