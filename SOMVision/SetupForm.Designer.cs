namespace SOMVision
{
    partial class SetupForm
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
            this.tabSetupControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSetupApply = new System.Windows.Forms.Button();
            this.cbCameraType = new System.Windows.Forms.ComboBox();
            this.lblCameraType = new System.Windows.Forms.Label();
            this.tabSetupControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSetupControl
            // 
            this.tabSetupControl.Controls.Add(this.tabPage1);
            this.tabSetupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSetupControl.Location = new System.Drawing.Point(0, 0);
            this.tabSetupControl.Name = "tabSetupControl";
            this.tabSetupControl.SelectedIndex = 0;
            this.tabSetupControl.Size = new System.Drawing.Size(800, 450);
            this.tabSetupControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSetupApply);
            this.tabPage1.Controls.Add(this.cbCameraType);
            this.tabPage1.Controls.Add(this.lblCameraType);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Camera";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSetupApply
            // 
            this.btnSetupApply.Location = new System.Drawing.Point(138, 61);
            this.btnSetupApply.Name = "btnSetupApply";
            this.btnSetupApply.Size = new System.Drawing.Size(75, 23);
            this.btnSetupApply.TabIndex = 2;
            this.btnSetupApply.Text = "적용";
            this.btnSetupApply.UseVisualStyleBackColor = true;
            this.btnSetupApply.Click += new System.EventHandler(this.btnSetupApply_Click);
            // 
            // cbCameraType
            // 
            this.cbCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameraType.FormattingEnabled = true;
            this.cbCameraType.Location = new System.Drawing.Point(92, 15);
            this.cbCameraType.Name = "cbCameraType";
            this.cbCameraType.Size = new System.Drawing.Size(121, 20);
            this.cbCameraType.TabIndex = 1;
            // 
            // lblCameraType
            // 
            this.lblCameraType.AutoSize = true;
            this.lblCameraType.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraType.Location = new System.Drawing.Point(8, 18);
            this.lblCameraType.Name = "lblCameraType";
            this.lblCameraType.Size = new System.Drawing.Size(79, 15);
            this.lblCameraType.TabIndex = 0;
            this.lblCameraType.Text = "카메라 종류: ";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabSetupControl);
            this.Name = "SetupForm";
            this.Text = "SetupForm";
            this.tabSetupControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetupControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblCameraType;
        private System.Windows.Forms.ComboBox cbCameraType;
        private System.Windows.Forms.Button btnSetupApply;
    }
}