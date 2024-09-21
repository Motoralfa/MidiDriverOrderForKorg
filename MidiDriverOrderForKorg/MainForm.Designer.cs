using System.Windows.Forms;

namespace MidiDriverOrderForKorg
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._tsUp = new System.Windows.Forms.ToolStripButton();
            this._tsDown = new System.Windows.Forms.ToolStripButton();
            this._tsMoveKorg = new System.Windows.Forms.ToolStripButton();
            this._lvContentMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._lvmiCopyRegKeyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this._miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._miQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this._miMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._miMoveKorgToTop = new System.Windows.Forms.ToolStripMenuItem();
            this._miCopyRegKeyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this._listView = new MidiDriverOrderForKorg.ListViewEx();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this._lvContentMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsRefresh,
            this.toolStripSeparator1,
            this._tsSave,
            this.toolStripSeparator2,
            this._tsUp,
            this._tsDown,
            this._tsMoveKorg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 39);
            this.toolStrip1.TabIndex = 6;
            // 
            // _tsRefresh
            // 
            this._tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("_tsRefresh.Image")));
            this._tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsRefresh.Name = "_tsRefresh";
            this._tsRefresh.Size = new System.Drawing.Size(36, 36);
            this._tsRefresh.ToolTipText = "Refresh driver list";
            this._tsRefresh.Click += new System.EventHandler(this.OnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // _tsSave
            // 
            this._tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsSave.Image = ((System.Drawing.Image)(resources.GetObject("_tsSave.Image")));
            this._tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsSave.Name = "_tsSave";
            this._tsSave.Size = new System.Drawing.Size(36, 36);
            this._tsSave.ToolTipText = "Save current order - Only the first 9 will be saved";
            this._tsSave.Click += new System.EventHandler(this.OnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // _tsUp
            // 
            this._tsUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsUp.Image = ((System.Drawing.Image)(resources.GetObject("_tsUp.Image")));
            this._tsUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsUp.Name = "_tsUp";
            this._tsUp.Size = new System.Drawing.Size(36, 36);
            this._tsUp.ToolTipText = "Move driver up - Only the first 9 will be saved";
            this._tsUp.Click += new System.EventHandler(this.OnMoveUp_Click);
            // 
            // _tsDown
            // 
            this._tsDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsDown.Image = ((System.Drawing.Image)(resources.GetObject("_tsDown.Image")));
            this._tsDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsDown.Name = "_tsDown";
            this._tsDown.Size = new System.Drawing.Size(36, 36);
            this._tsDown.ToolTipText = "Move driver down - Only the first 9 will be saved";
            this._tsDown.Click += new System.EventHandler(this.OnMoveDown_Click);
            // 
            // _tsMoveKorg
            // 
            this._tsMoveKorg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsMoveKorg.Image = ((System.Drawing.Image)(resources.GetObject("_tsMoveKorg.Image")));
            this._tsMoveKorg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsMoveKorg.Name = "_tsMoveKorg";
            this._tsMoveKorg.Size = new System.Drawing.Size(36, 36);
            this._tsMoveKorg.ToolTipText = "Move Korg drivers to the top";
            this._tsMoveKorg.Click += new System.EventHandler(this.OnMoveKorg_Click);
            // 
            // _lvContentMenu
            // 
            this._lvContentMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lvmiCopyRegKeyToClipboard});
            this._lvContentMenu.Name = "contextMenuStrip2";
            this._lvContentMenu.Size = new System.Drawing.Size(279, 26);
            // 
            // _lvmiCopyRegKeyToClipboard
            // 
            this._lvmiCopyRegKeyToClipboard.Name = "_lvmiCopyRegKeyToClipboard";
            this._lvmiCopyRegKeyToClipboard.Size = new System.Drawing.Size(278, 22);
            this._lvmiCopyRegKeyToClipboard.Text = "&Copy selected registry key to clipboard";
            this._lvmiCopyRegKeyToClipboard.Click += new System.EventHandler(this.CopyRegKeyToClipboard_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRefresh,
            this._miSave,
            this.toolStripSeparator3,
            this._miQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // _miRefresh
            // 
            this._miRefresh.Name = "_miRefresh";
            this._miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._miRefresh.Size = new System.Drawing.Size(138, 22);
            this._miRefresh.Text = "&Refresh";
            this._miRefresh.Click += new System.EventHandler(this._miRefresh_Click);
            // 
            // _miSave
            // 
            this._miSave.Name = "_miSave";
            this._miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._miSave.Size = new System.Drawing.Size(138, 22);
            this._miSave.Text = "&Save";
            this._miSave.Click += new System.EventHandler(this._miSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(135, 6);
            // 
            // _miQuit
            // 
            this._miQuit.Name = "_miQuit";
            this._miQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._miQuit.Size = new System.Drawing.Size(138, 22);
            this._miQuit.Text = "E&xit";
            this._miQuit.Click += new System.EventHandler(this._miQuit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miMoveUp,
            this._miMoveDown,
            this.toolStripSeparator4,
            this._miMoveKorgToTop,
            this._miCopyRegKeyToClipboard});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // _miMoveUp
            // 
            this._miMoveUp.Name = "_miMoveUp";
            this._miMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this._miMoveUp.Size = new System.Drawing.Size(320, 22);
            this._miMoveUp.Text = "Move &Up";
            this._miMoveUp.Click += new System.EventHandler(this._miMoveUp_Click);
            // 
            // _miMoveDown
            // 
            this._miMoveDown.Name = "_miMoveDown";
            this._miMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this._miMoveDown.Size = new System.Drawing.Size(320, 22);
            this._miMoveDown.Text = "Move &Down";
            this._miMoveDown.Click += new System.EventHandler(this._miMoveDown_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(317, 6);
            // 
            // _miMoveKorgToTop
            // 
            this._miMoveKorgToTop.Name = "_miMoveKorgToTop";
            this._miMoveKorgToTop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this._miMoveKorgToTop.Size = new System.Drawing.Size(320, 22);
            this._miMoveKorgToTop.Text = "Move &Korg drivers to the top";
            this._miMoveKorgToTop.Click += new System.EventHandler(this._miMoveKorgToTop_Click);
            // 
            // _miCopyRegKeyToClipboard
            // 
            this._miCopyRegKeyToClipboard.Name = "_miCopyRegKeyToClipboard";
            this._miCopyRegKeyToClipboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this._miCopyRegKeyToClipboard.Size = new System.Drawing.Size(320, 22);
            this._miCopyRegKeyToClipboard.Text = "&Copy selected registry key to clipboard";
            this._miCopyRegKeyToClipboard.Click += new System.EventHandler(this._miCopyRegKeyToClipboard_Click);
            // 
            // _listView
            // 
            this._listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this._listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listView.ContextMenuStrip = this._lvContentMenu;
            this._listView.FullRowSelect = true;
            this._listView.HideSelection = false;
            this._listView.Location = new System.Drawing.Point(8, 65);
            this._listView.Margin = new System.Windows.Forms.Padding(2);
            this._listView.MultiSelect = false;
            this._listView.Name = "_listView";
            this._listView.OverrideDoubleBuffered = true;
            this._listView.Size = new System.Drawing.Size(1165, 460);
            this._listView.TabIndex = 4;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            this._listView.SelectedIndexChanged += new System.EventHandler(this._listView_SelectedIndexChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // _miAbout
            // 
            this._miAbout.Name = "_miAbout";
            this._miAbout.Size = new System.Drawing.Size(180, 22);
            this._miAbout.Text = "About...";
            this._miAbout.Click += new System.EventHandler(this._miAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 536);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this._listView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._lvContentMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewEx _listView;
        private ToolStrip toolStrip1;
        private ToolStripButton _tsRefresh;
        private ToolStripButton _tsSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton _tsUp;
        private ToolStripButton _tsDown;
        private ToolStripButton _tsMoveKorg;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem _miQuit;
        private ToolStripMenuItem _miRefresh;
        private ToolStripMenuItem _miSave;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem _miMoveUp;
        private ToolStripMenuItem _miMoveDown;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem _miMoveKorgToTop;
        private ContextMenuStrip _lvContentMenu;
        private ToolStripMenuItem _lvmiCopyRegKeyToClipboard;
        private ToolStripMenuItem _miCopyRegKeyToClipboard;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem _miAbout;
    }
}