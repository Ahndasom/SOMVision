﻿namespace SOMVision
{
    partial class CameraForm
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
            this.mainViewToolbar1 = new SOMVision.UIControl.MainViewToolbar();
            this.imageViewer = new SOMVision.UIControl.ImageViewCtrl();
            this.SuspendLayout();
            // 
            // mainViewToolbar1
            // 
            this.mainViewToolbar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainViewToolbar1.Location = new System.Drawing.Point(644, 0);
            this.mainViewToolbar1.Name = "mainViewToolbar1";
            this.mainViewToolbar1.Size = new System.Drawing.Size(156, 450);
            this.mainViewToolbar1.TabIndex = 1;
            this.mainViewToolbar1.ButtonChanged += new System.EventHandler<SOMVision.UIControl.ToolbarEventArgs>(this.mainViewToolbar1_ButtonChanged);
            // 
            // imageViewer
            // 
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.imageViewer.Location = new System.Drawing.Point(0, 0);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(800, 450);
            this.imageViewer.TabIndex = 0;
            this.imageViewer.WorkingState = "";
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainViewToolbar1);
            this.Controls.Add(this.imageViewer);
            this.Name = "CameraForm";
            this.Text = "CameraForm";
            this.Resize += new System.EventHandler(this.CameraForm_Resize);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CameraForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.ImageViewCtrl imageViewer;
        private UIControl.MainViewToolbar mainViewToolbar1;
    }
}