namespace GameCaro
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
            this.pnlchessboard = new System.Windows.Forms.Panel();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.pctAvatar = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLan = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.pctbMark = new System.Windows.Forms.PictureBox();
            this.prcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.txbPlayerName = new System.Windows.Forms.TextBox();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qQuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctAvatar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlchessboard
            // 
            this.pnlchessboard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlchessboard.Location = new System.Drawing.Point(3, 38);
            this.pnlchessboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlchessboard.Name = "pnlchessboard";
            this.pnlchessboard.Size = new System.Drawing.Size(862, 875);
            this.pnlchessboard.TabIndex = 0;
            this.pnlchessboard.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvatar.Controls.Add(this.pctAvatar);
            this.pnlAvatar.Location = new System.Drawing.Point(873, 38);
            this.pnlAvatar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(432, 386);
            this.pnlAvatar.TabIndex = 1;
            // 
            // pctAvatar
            // 
            this.pctAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctAvatar.Image = global::GameCaro.Properties.Resources._394470ab186d4c50c8ec329b2b555ea2;
            this.pctAvatar.Location = new System.Drawing.Point(0, 0);
            this.pctAvatar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pctAvatar.Name = "pctAvatar";
            this.pctAvatar.Size = new System.Drawing.Size(426, 381);
            this.pctAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctAvatar.TabIndex = 0;
            this.pctAvatar.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnLan);
            this.panel3.Controls.Add(this.txbIP);
            this.panel3.Controls.Add(this.pctbMark);
            this.panel3.Controls.Add(this.prcbCoolDown);
            this.panel3.Controls.Add(this.txbPlayerName);
            this.panel3.Location = new System.Drawing.Point(877, 444);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 469);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 53);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 in a line to win";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnLan
            // 
            this.btnLan.Location = new System.Drawing.Point(4, 131);
            this.btnLan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLan.Name = "btnLan";
            this.btnLan.Size = new System.Drawing.Size(210, 43);
            this.btnLan.TabIndex = 4;
            this.btnLan.Text = "LAN";
            this.btnLan.UseVisualStyleBackColor = true;
            this.btnLan.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(4, 91);
            this.txbIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(208, 26);
            this.txbIP.TabIndex = 3;
            this.txbIP.Text = "127.0.0.1";
            // 
            // pctbMark
            // 
            this.pctbMark.BackColor = System.Drawing.SystemColors.Control;
            this.pctbMark.Location = new System.Drawing.Point(224, 5);
            this.pctbMark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pctbMark.Name = "pctbMark";
            this.pctbMark.Size = new System.Drawing.Size(198, 169);
            this.pctbMark.TabIndex = 2;
            this.pctbMark.TabStop = false;
            // 
            // prcbCoolDown
            // 
            this.prcbCoolDown.Location = new System.Drawing.Point(4, 45);
            this.prcbCoolDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prcbCoolDown.Name = "prcbCoolDown";
            this.prcbCoolDown.Size = new System.Drawing.Size(210, 37);
            this.prcbCoolDown.TabIndex = 1;
            this.prcbCoolDown.Click += new System.EventHandler(this.prcbCoolDown_Click);
            // 
            // txbPlayerName
            // 
            this.txbPlayerName.Location = new System.Drawing.Point(4, 5);
            this.txbPlayerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbPlayerName.Name = "txbPlayerName";
            this.txbPlayerName.ReadOnly = true;
            this.txbPlayerName.Size = new System.Drawing.Size(208, 26);
            this.txbPlayerName.TabIndex = 0;
            this.txbPlayerName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tmCoolDown
            // 
            this.tmCoolDown.Tick += new System.EventHandler(this.tmCoolDown_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1324, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.qQuToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // qQuToolStripMenuItem
            // 
            this.qQuToolStripMenuItem.Name = "qQuToolStripMenuItem";
            this.qQuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.qQuToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.qQuToolStripMenuItem.Text = "Quit";
            this.qQuToolStripMenuItem.Click += new System.EventHandler(this.qQuToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 952);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlAvatar);
            this.Controls.Add(this.pnlchessboard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Game Caro LAN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.pnlAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctAvatar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlchessboard;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbPlayerName;
        private System.Windows.Forms.ProgressBar prcbCoolDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLan;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.PictureBox pctbMark;
        private System.Windows.Forms.PictureBox pctAvatar;
        private System.Windows.Forms.Timer tmCoolDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qQuToolStripMenuItem;
    }
}

