using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstrLibrary.InstrObect
{
    public class AGT872ES_SCPI: NetWorkAnalyzerSCPIBase_Keysight
    {
        public AGT872ES_SCPI()
        {

        }

        public string 设置起始频率(string value)
        {
            return string.Format("STAR {0}MHz", value);
        }

        public string 设置停止频率(string value)
        {
            return string.Format("STOP {0}MHz", value);
        }


    }
}
