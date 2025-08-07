﻿using SOMVision.Core;
using SOMVision.Grab;
using SOMVision.Setting;
using SOMVision.Teach;
using SOMVision.Util;
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
            var resultWindow = new ResultForm();
            resultWindow.Show(cameraWindow.Pane, DockAlignment.Bottom, 0.3);
            var runWindow = new RunForm();
            runWindow.Show(resultWindow.Pane, DockAlignment.Right, 0.4);
            var modelTreeWindow = new ModelTreeForm();
            modelTreeWindow.Show(runWindow.Pane, DockAlignment.Bottom, 0.5);
            var propWindow = new PropertiesForm();
            propWindow.Show(_dockPanel, DockState.DockRight);
            var logWindow = new LogForm();
            logWindow.Show(propWindow.Pane, DockAlignment.Bottom, 0.3);
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
                    Global.Inst.InspStage.SetImageBuffer(filePath);
                    Global.Inst.InspStage.CurModel.InspectImagePath = filePath;
                    
                }
            }

        }
        private void setupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SLogger.Write($"환경설정창 열기");
            SetupForm setupForm = new SetupForm();
            setupForm.ShowDialog();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Inst.Dispose();
        }
        private string GetMdoelTitle(Model curModel)
        {
            if (curModel is null)
                return "";

            string modelName = curModel.ModelName;
            return $"{Define.PROGRAM_NAME} - MODEL : {modelName}";
        }

        private void modelNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewModel newModel = new NewModel();
            newModel.ShowDialog();

            Model curModel = Global.Inst.InspStage.CurModel;
            if (curModel != null)
            {
                this.Text = GetMdoelTitle(curModel);
            }
        }

        private void modelOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "모델 파일 선택";
                openFileDialog.Filter = "Model Files|*.xml;";
                openFileDialog.Multiselect = false;
                openFileDialog.InitialDirectory = SettingXml.Inst.ModelDir;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (Global.Inst.InspStage.LoadModel(filePath))
                    {
                        Model curModel = Global.Inst.InspStage.CurModel;
                        if (curModel != null)
                        {
                            this.Text = GetMdoelTitle(curModel);
                        }
                    }
                }
            }
        }

        private void modelSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Inst.InspStage.SaveModel("");
        }

        private void modelSaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = SettingXml.Inst.ModelDir;
                saveFileDialog.Title = "모델 파일 선택";
                saveFileDialog.Filter = "Model Files|*.xml;";
                saveFileDialog.DefaultExt = "xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    Global.Inst.InspStage.SaveModel(filePath);
                }
            }
        }
    }
}
