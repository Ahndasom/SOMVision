using SOMVision.Core;
using SOMVision.Grab;
using SOMVision.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2015;
namespace SOMVision
{
    public partial class MainForm : Form
    {
        private static DockPanel _dockPanel;
        public MainForm()
        {
            InitializeComponent();

            var spacerPanel = new Panel
            {
                Height = 5,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(41, 57, 85) // 눈에 보이지 않게
            };

            _dockPanel = new DockPanel
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_dockPanel);
            Controls.Add(spacerPanel);
            Controls.SetChildIndex(spacerPanel, 0); // MenuStrip 아래
            Controls.SetChildIndex(_dockPanel, 1);  // spacer 아래

            _dockPanel.Theme = new VS2015BlueTheme();

            LoadDockingWindows();

            //#6_INSP_STAGE#1 전역 인스턴스 초기화
            Global.Inst.Initialize();
        }
        private void LoadDockingWindows()
        {
            _dockPanel.AllowEndUserDocking = false;
            var cameraWindow = new CameraForm();
            cameraWindow.Show(_dockPanel, DockState.Document);

            var runWindow = new RunForm();
            runWindow.Show(cameraWindow.Pane, DockAlignment.Bottom, 0.2);
            var modelTreeWindow = new ModelTreeForm();
            modelTreeWindow.Show(runWindow.Pane, DockAlignment.Right, 0.3);
            var propWindow = new PropertiesForm();
            propWindow.Show(_dockPanel, DockState.DockRight);
        }

        public static T GetDockForm<T>() where T : DockContent
        {

            var findForm = _dockPanel.Contents.OfType<T>().FirstOrDefault();
            return findForm;
        }

        private void imageOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraForm cameraForm = GetDockForm<CameraForm>();
            if (cameraForm == null)
                return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "이미지 파일 선택";
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = false; //파일 하나만 선택 가능

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    cameraForm.LoadImage(filePath);
                }
            }

        }
        private void setupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.ShowDialog();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Inst.Dispose();
        }


    }
}
