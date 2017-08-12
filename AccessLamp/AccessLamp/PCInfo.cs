using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AccessLamp
{
	public class PCInfo
	{
		public char Drv;
		public PerformanceCounter R;
		public PerformanceCounter W;
		public int ErrorCount;

		public void Close()
		{
			this.Close(this.R);
			this.Close(this.W);
		}

		private void Close(PerformanceCounter pc)
		{
			try
			{
				pc.Close();
			}
			catch
			{ }
		}
	}
}
