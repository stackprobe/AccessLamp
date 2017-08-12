using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessLamp
{
	public class StringTools
	{
		public const string ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		public List<char> SelectValidCharFltr(List<char> chrs, string validChrs)
		{
			bool[] sw = new bool[validChrs.Length];

			foreach (char chr in chrs)
			{
				int index = validChrs.IndexOf(chr);

				if (index != -1)
				{
					sw[index] = true;
				}
			}
			List<char> buff = new List<char>();

			for (int index = 0; index < validChrs.Length; index++)
			{
				if (sw[index])
				{
					buff.Add(validChrs[index]);
				}
			}
			return buff;
		}

		public static void ToUnique(List<char> chrs)
		{
			for (int j = chrs.Count - 1; 0 <= j; j--)
			{
				for (int i = 0; i < j; i++)
				{
					if (chrs[i] == chrs[j])
					{
						chrs.RemoveAt(j);
						break;
					}
				}
			}
		}

		public static Encoding ENCODING_SJIS = Encoding.GetEncoding(932);

		public static string[] RemovePropsComments(string[] lines)
		{
			List<string> dest = new List<string>();

			foreach (string f_line in lines)
			{
				string line = f_line.Trim();

				if (line == "")
					continue;

				if (line.StartsWith(";"))
					continue;

				dest.Add(line);
			}
			return dest.ToArray();
		}
	}
}
