namespace SOMVision
{
    partial class ImageFilterProp
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRedo = new System.Windows.Forms.Button();
            this.checkFilter = new System.Windows.Forms.CheckBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSrc = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbFilterList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(122, 84);
            this.btnRedo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(50, 25);
            this.btnRedo.TabIndex = 30;
            this.btnRedo.Text = "다음";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // checkFilter
            // 
            this.checkFilter.AutoSize = true;
            this.checkFilter.Location = new System.Drawing.Point(12, 51);
            this.checkFilter.Name = "checkFilter";
            this.checkFilter.Size = new System.Drawing.Size(104, 16);
            this.checkFilter.TabIndex = 29;
            this.checkFilter.Text = "누적 필터 적용";
            this.checkFilter.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(68, 84);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(50, 25);
            this.btnUndo.TabIndex = 28;
            this.btnUndo.Text = "이전";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSrc
            // 
            this.btnSrc.Location = new System.Drawing.Point(176, 84);
            this.btnSrc.Margin = new System.Windows.Forms.Padding(2);
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(50, 25);
            this.btnSrc.TabIndex = 27;
            this.btnSrc.Text = "원본";
            this.btnSrc.UseVisualStyleBackColor = true;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 84);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(50, 25);
            this.btnApply.TabIndex = 26;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbFilterList
            // 
            this.cbFilterList.BackColor = System.Drawing.SystemColors.Info;
            this.cbFilterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbFilterList.FormattingEnabled = true;
            this.cbFilterList.Items.AddRange(new object[] {
            "Color → Mono",
            "Color → HSV",
            "Flip",
            "Pyramid",
            "Resize",
            "Binarization",
            "Canny Edge",
            "Morphology",
            "Rotation"});
            this.cbFilterList.Location = new System.Drawing.Point(12, 13);
            this.cbFilterList.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterList.Name = "cbFilterList";
            this.cbFilterList.Size = new System.Drawing.Size(214, 24);
            this.cbFilterList.TabIndex = 25;
            this.cbFilterList.SelectedIndexChanged += new System.EventHandler(this.cbFilterList_SelectedIndexChanged);
            // 
            // ImageFilterProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.checkFilter);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbFilterList);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ImageFilterProp";
            this.Size = new System.Drawing.Size(463, 307);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.CheckBox checkFilter;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSrc;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbFilterList;
    }
}
