using SOMVision.Core;
using SOMVision.Grab;
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
    public partial class SetupForm : DockContent
    {
        public SetupForm()
        {
            InitializeComponent();

            cbCameraType.Items.Add("사용 안 함");
            cbCameraType.Items.Add("WebCam");
            cbCameraType.Items.Add("HikRobotCam");

            var stage = Global.Inst?.InspStage;
            int selectedIndex = 0;

            if (stage != null)
            {
                switch (stage.GetCurrentCameraType())
                {
                    case CameraType.WebCam:
                        selectedIndex = 1;
                        break;
                    case CameraType.HikRobotCam:
                        selectedIndex = 2;
                        break;
                    case CameraType.None:
                    default:
                        selectedIndex = 0;
                        break;
                }
            }

            cbCameraType.SelectedIndex = selectedIndex;
        }

        private void btnSetupApply_Click(object sender, EventArgs e)
        {
            var stage = Global.Inst.InspStage;
            if (stage == null) return;

            int selectedIndex = cbCameraType.SelectedIndex;

            Console.WriteLine($"[btnApply_Click] 선택된 Index = {selectedIndex}");

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("[SetupForm] CameraType.None 설정");
                    stage.SetCameraType(CameraType.None);
                    return;
                case 1:
                    Console.WriteLine("[SetupForm] CameraType.WebCam 설정");
                    stage.SetCameraType(CameraType.WebCam);
                    break;
                case 2:
                    Console.WriteLine("[SetupForm] CameraType.HikRobotCam 설정");
                    stage.SetCameraType(CameraType.HikRobotCam);
                    break;
                default:
                    Console.WriteLine("[SetupForm] 알 수 없는 인덱스");
                    return;
            }

            stage.ReinitGrab();
        }
    }
}