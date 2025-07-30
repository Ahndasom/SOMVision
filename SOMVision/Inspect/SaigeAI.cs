using SaigeVision.Net.V2;
using SaigeVision.Net.V2.Segmentation;
using SaigeVision.Net.V2.Detection;
using SaigeVision.Net.V2.IAD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOMVision.Property;
using System.Diagnostics.Eventing.Reader;

namespace SOMVision.Inspect
{
    public class SaigeAI : IDisposable
    {
       
        public enum EngineType { IAD, IAD_BATCH, SEG, SEG_BATCH, CLS, CLS_BATCH, DET, OCR, IEN }
        public EngineType _engineType;

        private Dictionary<string, SegmentationResult> _segmentationResults;
        private Dictionary<string, IADResult> _IADResults;
        private Dictionary<string, DetectionResult> _detectionResults;

        IADEngine _iADEngine = null;
        IADResult _iADresult = null;
        SegmentationEngine _sEGEngine = null;
        SegmentationResult _sEGResult = null;
        DetectionEngine _dETEngine = null;
        DetectionResult _dETResult = null;


        Bitmap _inspImage = null;

        public SaigeAI()
        {
          
            _segmentationResults = new Dictionary<string, SegmentationResult>();
            _IADResults = new Dictionary<string, IADResult>();
            _detectionResults = new Dictionary<string, DetectionResult>();
        }

        public void SetEngineType(EngineType engineType)
        {
            _engineType = engineType;
        }

        public void LoadEngine(string modelPath)
        {

            _iADEngine?.Dispose();
            _sEGEngine?.Dispose();
            _dETEngine?.Dispose();

            switch (_engineType)
            {
                case EngineType.IAD:
                    _iADEngine = new IADEngine(modelPath, 0);
                    var iadOption = _iADEngine.GetInferenceOption();
                    iadOption.CalcScoremap = false;
                    iadOption.CalcHeatmap = false;
                    iadOption.CalcMask = false;
                    iadOption.CalcObject = true;
                    iadOption.CalcObjectAreaAndApplyThreshold = true;
                    iadOption.CalcObjectScoreAndApplyThreshold = true;
                    iadOption.CalcTime = true;
                    _iADEngine.SetInferenceOption(iadOption);
                    break;

                case EngineType.SEG:
                    _sEGEngine = new SegmentationEngine(modelPath, 0);
                    var segOption = _sEGEngine.GetInferenceOption();
                    segOption.CalcTime = true;
                    segOption.CalcObject = true;
                    segOption.CalcScoremap = false;
                    segOption.CalcMask = false;
                    segOption.CalcObjectAreaAndApplyThreshold = true;
                    segOption.CalcObjectScoreAndApplyThreshold = true;
                    _sEGEngine.SetInferenceOption(segOption);
                    break;

                case EngineType.DET:
                    _dETEngine = new DetectionEngine(modelPath, 0);
                    var detOption = _dETEngine.GetInferenceOption();
                    detOption.CalcTime = true;
                    _dETEngine.SetInferenceOption(detOption);
                    break;
            }
        }
        public bool Inspect(Bitmap bmpImage)
        {
            if (bmpImage == null)
            {
                MessageBox.Show("검사할 이미지가 없습니다.");
                return false;
            }

            _inspImage = bmpImage;
            SrImage srImage = new SrImage(bmpImage);
            Stopwatch sw = Stopwatch.StartNew();

            bool result = false;

            switch (_engineType)
            {
                case EngineType.SEG:
                    if (_sEGEngine == null)
                    {
                        MessageBox.Show("SEG 엔진이 초기화되지 않았습니다.");
                        return false;
                    }
                    _sEGResult = _sEGEngine.Inspection(srImage);
                    result = true;
                    break;

                case EngineType.IAD:
                    if (_iADEngine == null)
                    {
                        MessageBox.Show("IAD 엔진이 초기화되지 않았습니다.");
                        return false;
                    }
                    _iADresult = _iADEngine.Inspection(srImage);
                    result = true;
                    break;

                case EngineType.DET:
                    if (_dETEngine == null)
                    {
                        MessageBox.Show("DET 엔진이 초기화되지 않았습니다.");
                        return false;
                    }
                    _dETResult = _dETEngine.Inspection(srImage);
                    result = true;
                    break;

                default:
                    MessageBox.Show("지원하지 않는 엔진 타입입니다.");
                    return false;
            }

            sw.Stop();
            return result;
        }
        
        public void DrawResult(Bitmap bmp)
        {
            if (bmp == null)
                return;

            Graphics g = Graphics.FromImage(bmp);
            int step = 10;

            switch (_engineType)
            {
                case EngineType.SEG:
                    if (_sEGResult == null) return;

                    foreach (var prediction in _sEGResult.SegmentedObjects)
                    {
                        SolidBrush brush = new SolidBrush(Color.FromArgb(127, prediction.ClassInfo.Color));
                        using (GraphicsPath gp = new GraphicsPath())
                        {
                            if (prediction.Contour.Value.Count < 4) continue;
                            gp.AddPolygon(prediction.Contour.Value.ToArray());
                            foreach (var innerValue in prediction.Contour.InnerValue)
                            {
                                gp.AddPolygon(innerValue.ToArray());
                            }
                            g.FillPath(brush, gp);
                        }
                        step += 50;
                    }
                    break;

                case EngineType.IAD:
                    if (_iADresult == null) return;

                    foreach (var prediction in _iADresult.SegmentedObjects)
                    {
                        SolidBrush brush = new SolidBrush(Color.FromArgb(127, prediction.ClassInfo.Color));
                        using (GraphicsPath gp = new GraphicsPath())
                        {
                            if (prediction.Contour.Value.Count < 3) continue;
                            gp.AddPolygon(prediction.Contour.Value.ToArray());
                            foreach (var innerValue in prediction.Contour.InnerValue)
                            {
                                gp.AddPolygon(innerValue.ToArray());
                            }
                            g.FillPath(brush, gp);
                        }
                        step += 50;
                    
                    }
                    break;

                case EngineType.DET:
                    if (_dETResult == null) return;

                    foreach (var prediction in _dETResult.DetectedObjects)
                    {
                        SolidBrush brush = new SolidBrush(Color.FromArgb(127, prediction.ClassInfo.Color));
                        using (GraphicsPath gp = new GraphicsPath())
                        {
                            float x = (float)prediction.BoundingBox.X;
                            float y = (float)prediction.BoundingBox.Y;
                            float width = (float)prediction.BoundingBox.Width;
                            float height = (float)prediction.BoundingBox.Height;
                            gp.AddRectangle(new RectangleF(x, y, width, height));
                            g.DrawPath(new Pen(brush, 10), gp);
                        }
                        step += 50;
                    }
                    break;

                default:
                    MessageBox.Show("DrawResult: 지원하지 않는 엔진 타입입니다.");
                    break;
            }
        }

        public Bitmap GetResultImage()
        {
            if (_inspImage == null)
                return null;

            Bitmap resultImage = _inspImage.Clone(
                new Rectangle(0, 0, _inspImage.Width, _inspImage.Height),
                System.Drawing.Imaging.PixelFormat.Format24bppRgb
            );
            DrawResult(resultImage);
            return resultImage;
            
        }

        #region Disposable

        private bool disposed = false; // to detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                    // 검사완료 후 메모리 해제를 합니다.
                    // 엔진 사용이 완료되면 꼭 dispose 해주세요
                    if (_sEGEngine != null)
                        _sEGEngine.Dispose();
                }

                // Dispose unmanaged managed resources.

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion //Disposable
    }
}

