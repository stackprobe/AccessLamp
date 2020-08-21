namespace AccessLamp
{
	partial class MainWin
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.TaskTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.TTMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.TTMExit = new System.Windows.Forms.ToolStripMenuItem();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.TTMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// TaskTrayIcon
			// 
			this.TaskTrayIcon.ContextMenuStrip = this.TTMenu;
			this.TaskTrayIcon.Text = "準備しています...";
			// 
			// TTMenu
			// 
			this.TTMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TTMExit});
			this.TTMenu.Name = "TTIMenu";
			this.TTMenu.Size = new System.Drawing.Size(94, 26);
			// 
			// TTMExit
			// 
			this.TTMExit.Name = "TTMExit";
			this.TTMExit.Size = new System.Drawing.Size(93, 22);
			this.TTMExit.Text = "Exit";
			this.TTMExit.Click += new System.EventHandler(this.TTMExit_Click);
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Location = new System.Drawing.Point(-400, -400);
			this.Name = "MainWin";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "AccessLamp_MainWindow";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.TTMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon TaskTrayIcon;
		private System.Windows.Forms.ContextMenuStrip TTMenu;
		private System.Windows.Forms.ToolStripMenuItem TTMExit;
		private System.Windows.Forms.Timer MainTimer;
	}
}

