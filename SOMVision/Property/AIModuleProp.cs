using SaigeVision.Net.V2.OCR;
using SOMVision.Core;
using SOMVision.Inspect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SOMVision.Inspect.SaigeAI;

namespace SOMVision.Property
{
    public partial class AIModuleProp : UserControl
    {
        private SaigeAI.EngineType _engineType = SaigeAI.EngineType.SEG;
        private SaigeAI _saigeAI; // SaigeAI 인스턴스
        
        string _modelPath = string.Empty;

        public AIModuleProp()
        {
            InitializeComponent();
        }

        private void btnSelAIModel_Click(object sender, EventArgs e)
        {
            int selType = cbEngineList.SelectedIndex;
            string ext = "AI Files|*.*;";
            switch (selType)
            {
                case 0: // IAD
                    ext = "AI Files|*.saigeiad;";
                    break;
                case 1: // DET
                    ext = "AI Files|*.saigedet;";
                    break;
                case 2: // SEG
                    ext = "AI Files|*.saigeseg;";
                    break;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "AI 모델 파일 선택";
                openFileDialog.Filter = ext;
                openFileDialog.Multiselect = false;
                
                if (!string.IsNullOrEmpty(_modelPath))
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(_modelPath);
                else
                    openFileDialog.InitialDirectory = "C:\\Saige\\SaigeVision\\engine\\Examples\\data\\sfaw2023\\models";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _modelPath = openFileDialog.FileName;
                    txtAIModelPath.Text = _modelPath;
                }
            }
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_modelPath))
            {
                MessageBox.Show("모델 파일을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_saigeAI == null)
            {
                _saigeAI = Global.Inst.InspStage.AIModule;
            }

            _saigeAI.LoadEngine(_modelPath);
            MessageBox.Show("모델이 성공적으로 로드되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnInspAI_Click(object sender, EventArgs e)
        {
            if (_saigeAI == null)
            {
                MessageBox.Show("AI 모듈이 초기화되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap bitmap = Global.Inst.InspStage.GetCurrentImage();

            //Bitmap bitmap = Global.Inst.InspStage.AIModule.GetTestImage(); // 테스트 이미지 가져오기

            _saigeAI.Inspect(bitmap);

            Bitmap resultImage = _saigeAI.GetResultImage();

            Global.Inst.InspStage.UpdateDisplay(resultImage);
        }

        private void cbEngineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbEngineList.SelectedIndex)
            {
                case 0:
                    _engineType = SaigeAI.EngineType.IAD;
                    break;
                case 1:
                    _engineType = SaigeAI.EngineType.DET;
                    break;
                case 2:
                    _engineType = SaigeAI.EngineType.SEG;
                    break;
            }

            if (_saigeAI == null)
                _saigeAI = Global.Inst.InspStage.AIModule;

            _saigeAI.SetEngineType(_engineType);  
        }
    }

}
           