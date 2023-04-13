namespace WindowsFormsApplication1
{
    partial class menu
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
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporotDeChaqueClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reperotDesTousClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientToolStripMenuItem,
            this.operationToolStripMenuItem,
            this.reporotDeChaqueClientToolStripMenuItem,
            this.reperotDesTousClientsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.clientToolStripMenuItem.Text = "client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.operationToolStripMenuItem.Text = "operation";
            this.operationToolStripMenuItem.Click += new System.EventHandler(this.operationToolStripMenuItem_Click);
            // 
            // reporotDeChaqueClientToolStripMenuItem
            // 
            this.reporotDeChaqueClientToolStripMenuItem.Name = "reporotDeChaqueClientToolStripMenuItem";
            this.reporotDeChaqueClientToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.reporotDeChaqueClientToolStripMenuItem.Text = "reporot de chaque client";
            this.reporotDeChaqueClientToolStripMenuItem.Click += new System.EventHandler(this.reporotDeChaqueClientToolStripMenuItem_Click);
            // 
            // reperotDesTousClientsToolStripMenuItem
            // 
            this.reperotDesTousClientsToolStripMenuItem.Name = "reperotDesTousClientsToolStripMenuItem";
            this.reperotDesTousClientsToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.reperotDesTousClientsToolStripMenuItem.Text = "reperot des tous clients";
            this.reperotDesTousClientsToolStripMenuItem.Click += new System.EventHandler(this.reperotDesTousClientsToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 371);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "menu";
            this.Text = "menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporotDeChaqueClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reperotDesTousClientsToolStripMenuItem;
    }
}