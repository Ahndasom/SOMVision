using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMVision.Algorithm
{
    public class ImageFilterAlgorithm 
    {
        public class FilterStep
        {
            public FilterType Filter { get; set; }
            public Dictionary<string, object> Options { get; set; } = new Dictionary<string, object>();
        }

        /// <summary>실행할 필터 스텝들(순서 보장)</summary>
        public List<FilterStep> Steps { get; set; } = new List<FilterStep>();
       
    }
}
   