using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// Keysight
    /// 
    /// 频谱仪-SCPI指令
    /// </summary>
    public class SpectrumAnalyzerSCPIBase_Keysight : SCPIBase
    {
        public CALCulate_System CALC_SYSTEM = new CALCulate_System();
        public SENSe_System SENSE_SYSTEM = new SENSe_System();
        public DISPlay_System DISPLAY_SYSTEM = new DISPlay_System();

        /// <summary>
        /// SENSE指令系统
        /// </summary>
        public class SENSe_System
        {
            /// <summary>
            /// 设置起始频率 FREQ:STAR 100MHz
            /// </summary>
            /// <param name="pinlv"></param>
            /// <returns></returns>
            public virtual string 设置起始频率Start(string pinlv = "100MHz")
            {
                return string.Format("FREQ:STAR {0}", pinlv);
            }

            /// <summary>
            /// 设置终止频率 FREQ:STOP 200MHz
            /// </summary>
            /// <param name="pinlv"></param>s
            /// <returns></returns>
            public virtual string 设置终止频率stop(string pinlv = "200MHz")
            {
                return string.Format("FREQ:STOP {0}", pinlv);
            }

            /// <summary>
            /// 设置Span FREQ:SPAN 20MHz
            /// </summary>
            /// <param name="pinlv"></param>
            /// <returns></returns>
            public virtual string 设置Span(string pinlv = "20MHz")
            {
                return string.Format("FREQ:SPAN {0}", pinlv);
            }

            /// <summary>
            /// 设置RBW BAND:RES 20KHz
            /// </summary>
            /// <param name="pinlv"></param>
            /// <returns></returns>
            public virtual string 设置RBW(string pinlv = "20KHz")
            {
                return string.Format("BAND:RES {0}", pinlv);
            }

            /// <summary>
            /// 设置VBW BAND:VID 20KHz
            /// </summary>
            /// <param name="pinlv"></param>
            /// <returns></returns>
            public virtual string 设置VBW(string pinlv = "20KHz")
            {
                return string.Format("BAND:VID {0}", pinlv);
            }

            /// <summary>
            /// 设置扫频时间 SWE:TIME 10ms
            /// </summary>
            /// <param name="time"></param>
            /// <returns></returns>
            public virtual string 设置SweepTime(string time = "10ms")
            {
                return string.Format("SWE:TIME {0}", time);
            }
        }
        /// <summary>
        /// DISPlay系统
        /// </summary>
        public class DISPlay_System
        {
            /// <summary>
            /// 设置参考电平 DISPlay:WINDow{0}:TRACe:Y:RLEVel {0}
            /// </summary>
            /// <param name="win"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 设置参考电平(string win = "1",string value="20")
            {
                return string.Format("DISPlay:WINDow{0}:TRACe:Y:RLEVel {1}",win,value);
            }
        }
        /// <summary>
        /// CALC指令系统
        /// </summary>
        public class CALCulate_System
        {
            /// <summary>
            /// 开关MARK点 CALC:MARK1:STAT ON
            /// </summary>
            /// <param name="mknum">MARK的序数</param>
            /// <param name="state">ON | OFF</param>
            /// <returns></returns>
            public virtual string 开or关MARK点(int mknum = 1, string state = "ON")
            {
                return string.Format("CALC:MARK{0}:STAT {1}", mknum, state);
            }

            /// <summary>
            /// 设置MARK点 | CALC:MARK1:X 200MHz
            /// </summary>
            /// <param name="mknum">MARK序数</param>
            /// <param name="value">频率值</param>
            /// <returns></returns>
            public virtual string 设置MARK点(int mknum = 1, string value = "200MHz")
            {
                return string.Format("CALC:MARK{0}:X {1}", mknum, value);
            }

            /// <summary>
            /// 读取MARK点 | CALC:MARK1:Y?
            /// </summary>
            /// <param name="mknum">MARK序数</param>
            /// <returns></returns>
            public virtual string 读取MARK点(int mknum = 1)
            {
                return string.Format("CALC:MARK{0}:Y?", mknum);
            }

            /// <summary>
            /// 设置MARK最大MAX | CALC:MARK1:MAX
            /// </summary>
            /// <param name="mknum">MARK序数</param>
            /// <returns></returns>
            public virtual string 设置MARK最大MAX(int mknum = 1)
            {
                return string.Format("CALC:MARK{0}:MAX", mknum);
            }
        }
    }

    
}
