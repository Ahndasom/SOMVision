using SOMVision.Sequence;
using SOMVision.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SOMVision.Setting
{
    public partial class CommunicatorSetting : UserControl
    {
        private TextBox txtMachine;
        private Label lbMachine;
        private Button btnApply;
        private TextBox txtIpAddr;
        private ComboBox cbCommType;
        private Label laIpAddr;
        private Label lbCommType;

        public CommunicatorSetting()
        {
            InitializeComponent();

            //최초 로딩시, 환경설정 정보 로딩
            LoadSetting();
        }

        private void LoadSetting()
        {
            cbCommType.DataSource = Enum.GetValues(typeof(CommunicatorType)).Cast<CommunicatorType>().ToList();

            txtMachine.Text = SettingXml.Inst.MachineName;
            //환경설정에서 현재 통신 타입 얻기
            cbCommType.SelectedIndex = (int)SettingXml.Inst.CommType;

            txtIpAddr.Text = SettingXml.Inst.CommIP;
        }

        private void SaveSetting()
        {
            SettingXml.Inst.MachineName = txtMachine.Text;

            //환경설정에 통신 타입 설정
            SettingXml.Inst.CommType = (CommunicatorType)cbCommType.SelectedIndex;

            //통신 IP 설정
            SettingXml.Inst.CommIP = txtIpAddr.Text;

            //환경설정 저장
            SettingXml.Save();

            SLogger.Write($"통신 설정 저장");
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }
        private void InitializeComponent()
        {
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.lbMachine = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.cbCommType = new System.Windows.Forms.ComboBox();
            this.laIpAddr = new System.Windows.Forms.Label();
            this.lbCommType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(113, 11);
            this.txtMachine.Margin = new System.Windows.Forms.Padding(4);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(201, 28);
            this.txtMachine.TabIndex = 20;
            // 
            // lbMachine
            // 
            this.lbMachine.AutoSize = true;
            this.lbMachine.Location = new System.Drawing.Point(13, 15);
            this.lbMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMachine.Name = "lbMachine";
            this.lbMachine.Size = new System.Drawing.Size(62, 18);
            this.lbMachine.TabIndex = 19;
            this.lbMachine.Text = "설비명";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(209, 131);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(107, 34);
            this.btnApply.TabIndex = 18;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(113, 90);
            this.txtIpAddr.Margin = new System.Windows.Forms.Padding(4);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(201, 28);
            this.txtIpAddr.TabIndex = 17;
            // 
            // cbCommType
            // 
            this.cbCommType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommType.FormattingEnabled = true;
            this.cbCommType.Location = new System.Drawing.Point(113, 51);
            this.cbCommType.Margin = new System.Windows.Forms.Padding(4);
            this.cbCommType.Name = "cbCommType";
            this.cbCommType.Size = new System.Drawing.Size(201, 26);
            this.cbCommType.TabIndex = 16;
            // 
            // laIpAddr
            // 
            this.laIpAddr.AutoSize = true;
            this.laIpAddr.Location = new System.Drawing.Point(13, 95);
            this.laIpAddr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.laIpAddr.Name = "laIpAddr";
            this.laIpAddr.Size = new System.Drawing.Size(64, 18);
            this.laIpAddr.TabIndex = 15;
            this.laIpAddr.Text = "IP 주소";
            // 
            // lbCommType
            // 
            this.lbCommType.AutoSize = true;
            this.lbCommType.Location = new System.Drawing.Point(13, 55);
            this.lbCommType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCommType.Name = "lbCommType";
            this.lbCommType.Size = new System.Drawing.Size(80, 18);
            this.lbCommType.TabIndex = 14;
            this.lbCommType.Text = "통신타입";
            // 
            // CommunicatorSetting
            // 
            this.Controls.Add(this.txtMachine);
            this.Controls.Add(this.lbMachine);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtIpAddr);
            this.Controls.Add(this.cbCommType);
            this.Controls.Add(this.laIpAddr);
            this.Controls.Add(this.lbCommType);
            this.Name = "CommunicatorSetting";
            this.Size = new System.Drawing.Size(347, 186);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
