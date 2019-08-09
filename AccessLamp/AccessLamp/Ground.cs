using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AccessLamp
{
	public static class Gnd
	{
		public static EventWaitHandle Ev停止 = new EventWaitHandle(false, EventResetMode.AutoReset, "{724dbc96-8500-4758-adb2-dfcfbc6d8426}"); // shared_uuid
	}
}
