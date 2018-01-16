namespace AccessLamp2
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
			this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.TTMExit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.positionFixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.MainPic = new System.Windows.Forms.PictureBox();
			this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.darkCyanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainPic)).BeginInit();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TTMExit,
            this.toolStripMenuItem1,
            this.topMostToolStripMenuItem,
            this.positionFixedToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
			this.MainMenu.Name = "TTIMenu";
			this.MainMenu.Size = new System.Drawing.Size(170, 120);
			// 
			// TTMExit
			// 
			this.TTMExit.Name = "TTMExit";
			this.TTMExit.Size = new System.Drawing.Size(169, 22);
			this.TTMExit.Text = "Exit";
			this.TTMExit.Click += new System.EventHandler(this.TTMExit_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 6);
			// 
			// topMostToolStripMenuItem
			// 
			this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
			this.topMostToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.topMostToolStripMenuItem.Text = "Top Most";
			this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
			// 
			// positionFixedToolStripMenuItem
			// 
			this.positionFixedToolStripMenuItem.Name = "positionFixedToolStripMenuItem";
			this.positionFixedToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.positionFixedToolStripMenuItem.Text = "Position Fixed";
			this.positionFixedToolStripMenuItem.Click += new System.EventHandler(this.positionFixedToolStripMenuItem_Click);
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// MainPic
			// 
			this.MainPic.Location = new System.Drawing.Point(16, 20);
			this.MainPic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MainPic.Name = "MainPic";
			this.MainPic.Size = new System.Drawing.Size(200, 200);
			this.MainPic.TabIndex = 1;
			this.MainPic.TabStop = false;
			this.MainPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPic_MouseDown);
			this.MainPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPic_MouseMove);
			// 
			// backgroundColorToolStripMenuItem
			// 
			this.backgroundColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.darkCyanToolStripMenuItem,
            this.whiteToolStripMenuItem});
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.backgroundColorToolStripMenuItem.Text = "Background Color";
			// 
			// blackToolStripMenuItem
			// 
			this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
			this.blackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.blackToolStripMenuItem.Text = "Black";
			this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
			// 
			// darkCyanToolStripMenuItem
			// 
			this.darkCyanToolStripMenuItem.Name = "darkCyanToolStripMenuItem";
			this.darkCyanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.darkCyanToolStripMenuItem.Text = "Dark Cyan";
			this.darkCyanToolStripMenuItem.Click += new System.EventHandler(this.darkCyanToolStripMenuItem_Click);
			// 
			// whiteToolStripMenuItem
			// 
			this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
			this.whiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.whiteToolStripMenuItem.Text = "White";
			this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.ContextMenuStrip = this.MainMenu;
			this.Controls.Add(this.MainPic);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainWin";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "AccessLamp2";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWin_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWin_MouseMove);
			this.MainMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MainPic)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem TTMExit;
		private System.Windows.Forms.Timer MainTimer;
		private System.Windows.Forms.PictureBox MainPic;
		private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem positionFixedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem darkCyanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
	}
}

