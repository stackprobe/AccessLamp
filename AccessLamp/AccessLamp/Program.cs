using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

namespace AccessLamp
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			SystemEvents.SessionEnding += new SessionEndingEventHandler(SessionEnding);

			Mutex mtx = new Mutex(false, "{a6a3ac10-cf4a-48b6-8f53-c949e8db87fb}"); // shared_uuid

			if (mtx.WaitOne(0) == false) // 多重起動防止
			{
				Mutex mtx_2 = new Mutex(false, "{6aee517a-a9b1-4ec9-81d2-5f3965544641}"); // shared_uuid

				if (mtx_2.WaitOne(0) == false)
					return;

				Gnd.Ev停止.Set();

				bool mtxOk = mtx.WaitOne(5000);

				mtx_2.ReleaseMutex();
				mtx_2.Close();

				if (mtxOk == false)
					return;
			}
			LogTools.Clear();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWin());

			mtx.ReleaseMutex();
			mtx.Close();
		}

		public static string APP_TITLE = "AccessLamp";

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			try
			{
				MessageBox.Show(
					"[Application_ThreadException]\n" + e.Exception,
					"AccessLamp Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
			catch
			{ }

			Environment.Exit(1);
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				MessageBox.Show(
					"[CurrentDomain_UnhandledException]\n" + e.ExceptionObject,
					"AccessLamp Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
			catch
			{ }

			Environment.Exit(2);
		}

		private static void SessionEnding(object sender, SessionEndingEventArgs e)
		{
			Environment.Exit(3);
		}
	}
}
