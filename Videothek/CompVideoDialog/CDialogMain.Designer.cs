namespace VideoDialog
{
    partial class CDialogMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.suchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausleiheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neueAusleiheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausleiheVerlängernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rückgabeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suchenToolStripMenuItem,
            this.ausleiheToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // suchenToolStripMenuItem
            // 
            this.suchenToolStripMenuItem.Name = "suchenToolStripMenuItem";
            this.suchenToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.suchenToolStripMenuItem.Text = "Suchen";
            this.suchenToolStripMenuItem.Click += new System.EventHandler(this.SuchenToolStripMenuItem_Click);
            // 
            // ausleiheToolStripMenuItem
            // 
            this.ausleiheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueAusleiheToolStripMenuItem,
            this.ausleiheVerlängernToolStripMenuItem,
            this.rückgabeToolStripMenuItem});
            this.ausleiheToolStripMenuItem.Name = "ausleiheToolStripMenuItem";
            this.ausleiheToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.ausleiheToolStripMenuItem.Text = "Ausleihe";
            // 
            // neueAusleiheToolStripMenuItem
            // 
            this.neueAusleiheToolStripMenuItem.Name = "neueAusleiheToolStripMenuItem";
            this.neueAusleiheToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neueAusleiheToolStripMenuItem.Text = "Neue Ausleihe";
            this.neueAusleiheToolStripMenuItem.Click += new System.EventHandler(this.NeueAusleiheToolStripMenuItem_Click);
            // 
            // ausleiheVerlängernToolStripMenuItem
            // 
            this.ausleiheVerlängernToolStripMenuItem.Name = "ausleiheVerlängernToolStripMenuItem";
            this.ausleiheVerlängernToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ausleiheVerlängernToolStripMenuItem.Text = "Ausleihe verlängern";
            this.ausleiheVerlängernToolStripMenuItem.Click += new System.EventHandler(this.AusleiheVerlängernToolStripMenuItem_Click);
            // 
            // rückgabeToolStripMenuItem
            // 
            this.rückgabeToolStripMenuItem.Name = "rückgabeToolStripMenuItem";
            this.rückgabeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rückgabeToolStripMenuItem.Text = "Rückgabe";
            this.rückgabeToolStripMenuItem.Click += new System.EventHandler(this.RückgabeToolStripMenuItem_Click);
            // 
            // CDialogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VideoDialog.Properties.Resources.Videothek_verleihhüllen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 507);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CDialogMain";
            this.Text = "Videothek";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem suchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausleiheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neueAusleiheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausleiheVerlängernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rückgabeToolStripMenuItem;
    }
}