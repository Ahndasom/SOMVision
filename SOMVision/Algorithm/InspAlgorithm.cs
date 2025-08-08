using OpenCvSharp;
using SOMVision.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SaigeVision.Net.V2;

namespace SOMVision.Algorithm
{
    
    [XmlInclude(typeof(MatchAlgorithm))]
    [XmlInclude(typeof(BlobAlgorithm))]
    public abstract class InspAlgorithm
    {
        //알고리즘 타입 정의
        public InspectType InspectType { get; set; } = InspectType.InspNone;

        //알고지즘을 사용할지 여부 결정
        public bool IsUse { get; set; } = true;
        //검사가 완료되었는지를 판단
        public bool IsInspected { get; set; } = false;
        public Rect TeachRect { get; set; }
        public Rect InspRect { get; set; }
        public eImageChannel ImageChannel { get; set; } = eImageChannel.Gray;
        //검사할 원본 이미지
        protected Mat _srcImage = null;

        //검사 결과 정보
        public List<string> ResultString { get; set; } = new List<string>();

        //불량 여부
        public bool IsDefect { get; set; }

        public abstract InspAlgorithm Clone();
        public abstract bool CopyFrom(InspAlgorithm sourceAlgo);
        protected void CopyBaseTo(InspAlgorithm target)
        {
            target.InspectType = this.InspectType;
            target.IsUse = this.IsUse;
            target.IsInspected = this.IsInspected;
            target.TeachRect = this.TeachRect;
            target.InspRect = this.InspRect;
            // NOTE: _srcImage 는 런타임 검사용이라 복사하지 않음
        }
        public virtual void SetInspData(Mat srcImage)
        {
            _srcImage = srcImage;
        }

        //검사 함수로, 상속 받는 클래스는 필수로 구현해야한다.
        public abstract bool DoInspect();

        //검사 결과 정보 초기화
        public virtual void ResetResult()
        {
            IsInspected = false;
            IsDefect = false;
            ResultString.Clear();
        }
        public virtual int GetResultRect(out List<DrawInspectInfo> resultArea)
        {
            resultArea = null;
            return 0;
        }
    }
}
