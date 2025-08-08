namespace SOMVision
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.modelNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelSaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inspectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.inspectToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(979, 36);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageOpenToolStripMenuItem,
            this.imageSaveToolStripMenuItem,
            this.toolStripSeparator,
            this.modelNewToolStripMenuItem,
            this.modelOpenToolStripMenuItem,
            this.modelSaveToolStripMenuItem,
            this.modelSaveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 32);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // imageOpenToolStripMenuItem
            // 
            this.imageOpenToolStripMenuItem.Name = "imageOpenToolStripMenuItem";
            this.imageOpenToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.imageOpenToolStripMenuItem.Text = "Image Open";
            this.imageOpenToolStripMenuItem.Click += new System.EventHandler(this.imageOpenToolStripMenuItem_Click);
            // 
            // imageSaveToolStripMenuItem
            // 
            this.imageSaveToolStripMenuItem.Name = "imageSaveToolStripMenuItem";
            this.imageSaveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.imageSaveToolStripMenuItem.Text = "Image Save";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(267, 6);
            // 
            // modelNewToolStripMenuItem
            // 
            this.modelNewToolStripMenuItem.Name = "modelNewToolStripMenuItem";
            this.modelNewToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.modelNewToolStripMenuItem.Text = "Model New";
            this.modelNewToolStripMenuItem.Click += new System.EventHandler(this.modelNewToolStripMenuItem_Click);
            // 
            // modelOpenToolStripMenuItem
            // 
            this.modelOpenToolStripMenuItem.Name = "modelOpenToolStripMenuItem";
            this.modelOpenToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.modelOpenToolStripMenuItem.Text = "Model Open";
            this.modelOpenToolStripMenuItem.Click += new System.EventHandler(this.modelOpenToolStripMenuItem_Click);
            // 
            // modelSaveToolStripMenuItem
            // 
            this.modelSaveToolStripMenuItem.Name = "modelSaveToolStripMenuItem";
            this.modelSaveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.modelSaveToolStripMenuItem.Text = "Model Save";
            this.modelSaveToolStripMenuItem.Click += new System.EventHandler(this.modelSaveToolStripMenuItem_Click);
            // 
            // modelSaveAsToolStripMenuItem
            // 
            this.modelSaveAsToolStripMenuItem.Name = "modelSaveAsToolStripMenuItem";
            this.modelSaveAsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.modelSaveAsToolStripMenuItem.Text = "Model Save As";
            this.modelSaveAsToolStripMenuItem.Click += new System.EventHandler(this.modelSaveAsToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem1});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(75, 32);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // setupToolStripMenuItem1
            // 
            this.setupToolStripMenuItem1.Name = "setupToolStripMenuItem1";
            this.setupToolStripMenuItem1.Size = new System.Drawing.Size(161, 34);
            this.setupToolStripMenuItem1.Text = "Setup";
            this.setupToolStripMenuItem1.Click += new System.EventHandler(this.setupToolStripMenuItem1_Click);
            // 
            // inspectToolStripMenuItem
            // 
            this.inspectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cycleModeMenuItem});
            this.inspectToolStripMenuItem.Name = "inspectToolStripMenuItem";
            this.inspectToolStripMenuItem.Size = new System.Drawing.Size(87, 32);
            this.inspectToolStripMenuItem.Text = "Inspect";
            // 
            // cycleModeMenuItem
            // 
            this.cycleModeMenuItem.CheckOnClick = true;
            this.cycleModeMenuItem.Name = "cycleModeMenuItem";
            this.cycleModeMenuItem.Size = new System.Drawing.Size(270, 34);
            this.cycleModeMenuItem.Text = "Cycle Mode";
            this.cycleModeMenuItem.Click += new System.EventHandler(this.cycleModeMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 568);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem modelNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelSaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inspectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleModeMenuItem;
    }
}