using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Reflection;

namespace AccessLamp2
{
	public partial class MainWin : Form
	{
		#region ALT_F4 抑止

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x112;
			const long SC_CLOSE = 0xF060L;

			if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
				return;

			base.WndProc(ref m);
		}

		#endregion

		public MainWin()
		{
			InitializeComponent();
		}

		private Image IconIdle;
		private Image IconR;
		private Image IconW;
		private Image IconRW;
		private Image IconBusyR;
		private Image IconBusyW;
		private Image IconBusyRW;
		public List<PCInfo> PCList = new List<PCInfo>();

		public string GetTTIText()
		{
			StringBuilder buff = new StringBuilder();

			foreach (PCInfo info in this.PCList)
			{
				buff.Append(info.Drv);
			}
			return "見ているドライブ: " + buff;
		}

		private static string GetIconFile(string localFile)
		{
			if (File.Exists(localFile))
				return localFile;

			try
			{
				string selfFile = Assembly.GetEntryAssembly().Location;
				string selfDir = Path.GetDirectoryName(selfFile);
				string selfDirFile = Path.Combine(selfDir, localFile);

				if (File.Exists(selfDirFile))
					return selfDirFile;
			}
			catch
			{ }

			return Path.Combine("..\\..\\..\\..\\..\\..\\icon", localFile);
		}

		private static int Icon_W = 16;
		private static int Icon_H = 16;

		private static Image LoadIcon_Main(string localFile)
		{
			try
			{
				return Image.FromFile(GetIconFile(localFile));
			}
			catch
			{
				MessageBox.Show(
					"アイコンファイル '" + localFile + "' の読み込みに失敗しました。\n" +
					"作業フォルダまたは実行ファイルと同じフォルダにアイコンファイルが存在することを確認して下さい。",
					"AccessLamp2 Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);

				return SystemIcons.Error.ToBitmap();
			}
		}

		private static Image LoadIcon(string localFile)
		{
			Image image = LoadIcon_Main(localFile);

			Icon_W = Math.Max(Icon_W, image.Width);
			Icon_H = Math.Max(Icon_H, image.Height);

			return image;
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			this.IconIdle = LoadIcon("Idle.ico");
			this.IconR = LoadIcon("Read.ico");
			this.IconW = LoadIcon("Write.ico");
			this.IconRW = LoadIcon("ReadWrite.ico");
			this.IconBusyR = LoadIcon("BusyRead.ico");
			this.IconBusyW = LoadIcon("BusyWrite.ico");
			this.IconBusyRW = LoadIcon("BusyReadWrite.ico");

			{
				Exception firstEx = null;
				List<char> drvs = new List<char>();

				try
				{
					string[] args = Environment.GetCommandLineArgs();

					for (int index = 1; index < args.Length; index++)
					{
						foreach (char chr in args[index].ToUpper())
						{
							if (StringTools.ALPHA.Contains(chr))
							{
								drvs.Add(chr);
							}
						}
					}
				}
				catch
				{ }

				if (drvs.Count == 0)
				{
					foreach (char drv in StringTools.ALPHA)
					{
						DriveInfo di = new DriveInfo("" + drv);

						if (di.DriveType == DriveType.Fixed)
						{
							drvs.Add(drv);
						}
					}
				}
				StringTools.ToUnique(drvs);

				foreach (char drv in drvs)
				{
					try
					{
						PerformanceCounter r = new PerformanceCounter("LogicalDisk", "Disk Read Bytes/sec", drv + ":");
						PerformanceCounter w = new PerformanceCounter("LogicalDisk", "Disk Write Bytes/sec", drv + ":");

						PCInfo info = new PCInfo();

						info.Drv = drv;
						info.R = r;
						info.W = w;

						this.PCList.Add(info);
					}
					catch (Exception ex)
					{
						if (firstEx == null)
							firstEx = ex;
					}
				}
				if (this.PCList.Count == 0)
				{
					string sDrv = new string(drvs.ToArray());

					MessageBox.Show(
						"パフォーマンスカウンタのオープンに失敗しました。\ndrv: " + sDrv + "\nex: " + firstEx,
						"AccessLamp2 Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
						);
				}
			}

			GC.Collect();
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			this.Left = Gnd.MainWin_L;
			this.Top = Gnd.MainWin_T;
			this.Width = Icon_W;
			this.Height = Icon_H;

			this.MainPic.Left = 0;
			this.MainPic.Top = 0;
			this.MainPic.Width = Icon_W;
			this.MainPic.Height = Icon_H;

			this.MainPic.Image = this.IconIdle;

			this.BackColor = Color.DarkCyan;

			this.UIRefresh();

			this.MT_Enabled = true;
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			Gnd.MainWin_L = this.Left;
			Gnd.MainWin_T = this.Top;

			Gnd.Save(Gnd.SettingFile);
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;

			foreach (PCInfo info in this.PCList)
			{
				info.Close();
			}
		}

		private int Chain_R;
		private int Chain_W;

		private bool ChainFltr(bool f, ref int c)
		{
			const int C_MAX = 3;

			if (f)
			{
				if (c < C_MAX)
					c++;
			}
			else
			{
				if (0 < c)
					c--;
			}
			return c == C_MAX;
		}

		private bool MT_Enabled;
		private bool MT_Busy;
		private long MT_Count;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MT_Enabled == false || this.MT_Busy)
				return;

			this.MT_Busy = true;

			int currPCPos = -1;

			try
			{
				bool rf = false;
				bool wf = false;

				for (int index = 0; index < this.PCList.Count; index++)
				{
					currPCPos = index;

					if (0f < this.PCList[index].R.NextValue())
						rf = true;

					if (0f < this.PCList[index].W.NextValue())
						wf = true;

					currPCPos = -1;
					this.PCList[index].ErrorCount = 0;
				}

				bool sf =
					this.ChainFltr(rf, ref this.Chain_R) ||
					this.ChainFltr(wf, ref this.Chain_W);

				Image nextIcon = this.IconIdle;

				if (sf)
				{
					if (rf)
					{
						if (wf)
							nextIcon = this.IconBusyRW;
						else
							nextIcon = this.IconBusyR;
					}
					else // (sf && !rf) なら (wf) であるはず。
					{
						nextIcon = this.IconBusyW;
					}
				}
				else
				{
					if (rf)
					{
						if (wf)
							nextIcon = this.IconRW;
						else
							nextIcon = this.IconR;
					}
					else if (wf)
					{
						nextIcon = this.IconW;
					}
				}

				if (this.MainPic.Image != nextIcon)
					this.MainPic.Image = nextIcon;

				if (this.MT_Count % 6000 == 0) // 10分毎に実行
				{
					GC.Collect();
				}
				if (this.MT_Count % 30 == 0) // 3秒毎に実行
				{
					if (Gnd.Ev停止.WaitOne(0))
					{
						this.MT_Enabled = false;
						this.Close();
						return;
					}
				}
			}
			catch (Exception ex)
			{
				if (currPCPos == -1)
					throw ex;

				this.PCList[currPCPos].ErrorCount++;

				if (this.PCList[currPCPos].ErrorCount < 5) // < 0.5[sec]
					return;

				this.PCList[currPCPos].Close();
				this.PCList.RemoveAt(currPCPos);
			}
			finally
			{
				this.MT_Busy = false;
				this.MT_Count++;
			}
		}

		private void TTMExit_Click(object sender, EventArgs e)
		{
			this.MT_Enabled = false;
			this.Close();
		}

		private Point WinMvFrm;

		private void MainWin_MouseDown(object sender, MouseEventArgs e)
		{
			// noop
		}

		private void MainWin_MouseMove(object sender, MouseEventArgs e)
		{
			// noop
		}

		private void MainPic_MouseDown(object sender, MouseEventArgs e)
		{
			if (Gnd.PositionFixed == false)
			{
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				{
					this.WinMvFrm = new Point(e.X, e.Y);
				}
			}
		}

		private void MainPic_MouseMove(object sender, MouseEventArgs e)
		{
			if (Gnd.PositionFixed == false)
			{
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				{
					this.Location = new Point(
						this.Location.X + e.X - this.WinMvFrm.X,
						this.Location.Y + e.Y - this.WinMvFrm.Y
						);
				}
			}
		}

		private void UIRefresh()
		{
			this.TopMost = Gnd.MostTop;

			this.topMostToolStripMenuItem.Checked = Gnd.MostTop;
			this.positionFixedToolStripMenuItem.Checked = Gnd.PositionFixed;

			// Background Color
			{
				this.blackToolStripMenuItem.Checked = false;
				this.darkCyanToolStripMenuItem.Checked = false;
				this.whiteToolStripMenuItem.Checked = false;

				switch (Gnd.BackgroundColor)
				{
					case Gnd.BackgroundColor_e.Black:
						this.BackColor = Color.Black;
						this.blackToolStripMenuItem.Checked = true;
						break;

					case Gnd.BackgroundColor_e.DrakCyan:
						this.BackColor = Color.DarkCyan;
						this.darkCyanToolStripMenuItem.Checked = true;
						break;

					case Gnd.BackgroundColor_e.White:
						this.BackColor = Color.White;
						this.whiteToolStripMenuItem.Checked = true;
						break;

					default:
						throw null; // never
				}
			}
		}

		private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gnd.MostTop = Gnd.MostTop == false;
			this.UIRefresh();
		}

		private void positionFixedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gnd.PositionFixed = Gnd.PositionFixed == false;
			this.UIRefresh();
		}

		private void blackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gnd.BackgroundColor = Gnd.BackgroundColor_e.Black;
			this.UIRefresh();
		}

		private void darkCyanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gnd.BackgroundColor = Gnd.BackgroundColor_e.DrakCyan;
			this.UIRefresh();
		}

		private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gnd.BackgroundColor = Gnd.BackgroundColor_e.White;
			this.UIRefresh();
		}
	}
}
