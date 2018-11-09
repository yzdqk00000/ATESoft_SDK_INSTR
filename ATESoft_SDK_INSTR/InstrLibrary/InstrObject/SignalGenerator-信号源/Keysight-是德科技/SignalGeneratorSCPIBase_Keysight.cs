using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// Keysight
    /// 
    /// 信号源-SCPI指令
    /// </summary>
    public class SignalGeneratorSCPIBase_Keysight : SCPIBase
    {
        public POWer_System POWER_SYSTEM = new POWer_System();
        public FREQuency_System FREQUENCY_SYSTEM = new FREQuency_System();
        public OUTPut_System OUTPUT_SYSTEM = new OUTPut_System();

        /// <summary>
        /// POWER指令系统
        /// </summary>
        public class POWer_System
        {
            /// <summary>
            /// 设置功率|POWer {0}
            /// </summary>
            /// <param name="value">50dbm</param>
            /// <returns></returns>
            public virtual string 设置功率(string value)
            {
                return string.Format("POWer {0}",value);
            }

            /// <summary>
            /// 读取当前功率|POWer?
            /// </summary>
            /// <returns></returns>
            public virtual string 读取当前功率()
            {
                return string.Format("POWer?");
            }

        }

        /// <summary>
        /// FREQ指令系统
        /// </summary>
        public class FREQuency_System
        {
            /// <summary>
            /// 设置频率|FREQ {0}
            /// </summary>
            /// <param name="pinlv">50MHz</param>
            /// <returns></returns>
            public virtual string 设置频率(string pinlv)
            {
                return string.Format("FREQ {0}", pinlv);
            }

            /// <summary>
            /// 读取当前频率|FREQ?
            /// </summary>
            /// <returns></returns>
            public virtual string 读取当前频率()
            {
                return string.Format("FREQ?");
            }
        }


        /// <summary>
        /// OUTPut指令系统
        /// </summary>
        public class OUTPut_System
        {
            /// <summary>
            /// 打开关闭输出|OUTP {0}
            /// </summary>
            /// <param name="state"></param>
            /// <returns></returns>
            public virtual string 开or关输出(string state="OFF")
            {
                return string.Format("OUTP {0}",state);
            }


        }
    }

    
}
