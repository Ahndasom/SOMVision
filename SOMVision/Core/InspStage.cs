using OpenCvSharp;
using SOMVision.Algorithm;
using SOMVision.Grab;
using SOMVision.Inspect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SOMVision.Core
{
    //검사와 관련된 클래스를 관리하는 클래스
    public class InspStage : IDisposable
    {
        public static readonly int MAX_GRAB_BUF = 5;

        private ImageSpace _imageSpace = null;
        //private HikRobotCam _grabManager = null;
        private GrabModel _grabManager = null;
        private CameraType _camType = CameraType.None;

        SaigeAI _saigeAI; // SaigeAI 인스턴스
        BlobAlgorithm _blobAlgorithm = null; // Blob 알고리즘 인스턴스
        private PreviewImage _previewImage = null;
        public bool LiveMode { get; private set; } = false;

        public void ToggleLiveMode()
        {
            LiveMode = !LiveMode;
        }

        public InspStage() { }
        public ImageSpace ImageSpace
        {
            get => _imageSpace;
        }

        public SaigeAI AIModule
        {
            get
            {
                if (_saigeAI is null)
                    _saigeAI = new SaigeAI();
                return _saigeAI;
            }
        }
        public BlobAlgorithm BlobAlgorithm
        {
            get => _blobAlgorithm;
        }

        public PreviewImage PreView
        {
            get => _previewImage;
        }
        public void SetCameraType(CameraType camType)
        {
            Console.WriteLine($"[SetCameraType] 호출됨 - camType: {camType}");

            if (_camType == camType && camType != CameraType.None)
            {
                Console.WriteLine("[SetCameraType] 동일한 카메라 타입이므로 무시");
                return;
            }

            _camType = camType;

            _grabManager?.Dispose();
            _grabManager = null;

            if (_camType == CameraType.None)
            {
                Console.WriteLine("[SetCameraType] CameraType.None - grabManager 제거");
                return;
            }

            switch (_camType)
            {
                case CameraType.WebCam:
                    Console.WriteLine("[SetCameraType] WebCam 생성 시도");
                    _grabManager = new WebCam();
                    break;
                case CameraType.HikRobotCam:
                    Console.WriteLine("[SetCameraType] HikRobotCam 생성 시도");
                    _grabManager = new HikRobotCam();
                    break;
            }

            if (_grabManager != null)
            {
                bool result = _grabManager.InitGrab();
                Console.WriteLine($"[SetCameraType] GrabManager InitGrab() 결과: {result}");

                if (result)
                {
                    _grabManager.TransferCompleted += _multiGrab_TransferCompleted;
                    InitModelGrab(MAX_GRAB_BUF);
                }
                else
                {
                    _grabManager = null;
                    Console.WriteLine("[SetCameraType] InitGrab 실패로 GrabManager 제거");
                }
            }
            else
            {
                Console.WriteLine("[SetCameraType] GrabManager 생성 실패");
            }
        }
        public void ReinitGrab() 
        {
            if (_grabManager != null)
            {
                _grabManager.TransferCompleted -= _multiGrab_TransferCompleted;
                _grabManager.TransferCompleted += _multiGrab_TransferCompleted;
                InitModelGrab(MAX_GRAB_BUF);
            }
        }

        public CameraType GetCurrentCameraType()
        {
            return _camType;
        }
        public bool Initialize()
        {
            _imageSpace = new ImageSpace();
            _blobAlgorithm = new BlobAlgorithm();
            _previewImage = new PreviewImage();

            // 중복 Init 제거
            SetCameraType(_camType);

            return true;
        }

        public void InitModelGrab(int bufferCount)
        {
            if (_grabManager == null)
                return;

            int pixelBpp = 8;
            _grabManager.GetPixelBpp(out pixelBpp);

            int inspectionWidth;
            int inspectionHeight;
            int inspectionStride;
            _grabManager.GetResolution(out inspectionWidth, out inspectionHeight, out inspectionStride);

            if (_imageSpace != null)
            {
                _imageSpace.SetImageInfo(pixelBpp, inspectionWidth, inspectionHeight, inspectionStride);
            }

            SetBuffer(bufferCount);

            //_grabManager.SetExposureTime(25000);
            UpdateProperty();
        }

        private void UpdateProperty()
        {
            if (BlobAlgorithm is null)
                return;

            PropertiesForm propertiesForm = MainForm.GetDockForm<PropertiesForm>();
            if (propertiesForm is null)
                return;

            propertiesForm.UpdateProperty(BlobAlgorithm);
        }

        public void SetBuffer(int bufferCount)
        {
            if (_grabManager == null)
                return;

            if (_imageSpace.BufferCount == bufferCount)
                return;

            _imageSpace.InitImageSpace(bufferCount);
            _grabManager.InitBuffer(bufferCount);

            for (int i = 0; i < bufferCount; i++)
            {
                _grabManager.SetBuffer(
                    _imageSpace.GetInspectionBuffer(i),
                    _imageSpace.GetnspectionBufferPtr(i),
                    _imageSpace.GetInspectionBufferHandle(i),
                    i);
            }
        }


        public void Grab(int bufferIndex)
        {
            if (_camType == CameraType.None || _grabManager == null)
                return;

            _grabManager.Grab(bufferIndex, true);
        }

        //영상 취득 완료 이벤트 발생시 후처리
        private async void _multiGrab_TransferCompleted(object sender, object e)
        {
            int bufferIndex = (int)e;
            Console.WriteLine($"_multiGrab_TransferCompleted {bufferIndex}");

            _imageSpace.Split(bufferIndex);

            DisplayGrabImage(bufferIndex);
            if (LiveMode)
            {
                await Task.Delay(100); // 너무 빠른 촬영 방지
                _grabManager.Grab(bufferIndex, true); // 반복 촬영
            }
        }

        private void DisplayGrabImage(int bufferIndex)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.UpdateDisplay();
            }
        }

        public void UpdateDisplay(Bitmap bitmap)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.UpdateDisplay(bitmap);
            }
        }

        public Bitmap GetCurrentImage()
        {
            Bitmap bitmap = null;
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                bitmap = cameraForm.GetDisplayImage();
            }

            return bitmap;
        }

        public Bitmap GetBitmap(int bufferIndex = -1)
        {
            if (Global.Inst.InspStage.ImageSpace is null)
                return null;

            return Global.Inst.InspStage.ImageSpace.GetBitmap();
        }

        public Mat GetMat()
        {
            return Global.Inst.InspStage.ImageSpace.GetMat();
        }

        public void RedrawMainView()
        {
            CameraForm cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.UpdateImageViewer();
            }
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
                    if (_grabManager != null)
                    {
                        _grabManager.Dispose();
                        _grabManager = null;
                    }
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
