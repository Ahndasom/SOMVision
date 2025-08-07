using SOMVision.Core;
using SOMVision.Grab;
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

namespace SOMVision
{
    public partial class RunForm : DockContent
    {
        public RunForm()
        {
            InitializeComponent();
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            var stage = Global.Inst.InspStage;

            SLogger.Write($"[RunForm] 촬상 클릭됨. CameraType: {stage.GetCurrentCameraType()}");

            if (stage.GetCurrentCameraType() == CameraType.None)
            {
                MessageBox.Show("현재 선택된 카메라가 없습니다.");
                return;
            }

            stage.CheckImageBuffer();
            stage.Grab(0);
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            var stage = Global.Inst.InspStage;
            Global.Inst.InspStage.ToggleLiveMode();
            if (Global.Inst.InspStage.LiveMode)
            {
                SLogger.Write($"[RunForm] 동영상 모드 클릭됨. CameraType:{stage.GetCurrentCameraType()}");
                Global.Inst.InspStage.CheckImageBuffer();
                Global.Inst.InspStage.Grab(0); // 최초 시작
            }
            else
            {
                SLogger.Write($"[RunForm] 동영상 모드 중지됨. CameraType:{stage.GetCurrentCameraType()}");
            }

        }

        private void btnInsp_Click(object sender, EventArgs e)
        {
            SLogger.Write($"[RunForm] 검사 클릭됨.");
            Global.Inst.InspStage.TryInspection();
        }
    }
}
