using InstrLibrary.InstrDriver;
using System.Collections.Generic;

namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// Keysight
    /// 
    /// 信号源-SCPI指令
    /// </summary>
    public class SignalGeneratorSCPIBase_Keysight : SCPIBase
    {
        public SOURce_System SOURCE_SYSTEM = new SOURce_System();
        public OUTPut_System OUTPUT_SYSTEM = new OUTPut_System();

        /// <summary>
        /// SOURce指令系统
        /// </summary>
        public class SOURce_System
        {
            /// <summary>
            /// 设置频率|FREQ {0}
            /// </summary>
            /// <param name="pinlv">50MHz</param>
            /// <returns></returns>
            public virtual string 设置频率(string pinlv)
            {
                return string.Format("SOUR:FREQ {0}", pinlv);
            }

            /// <summary>
            /// 读取当前频率|FREQ?
            /// </summary>
            /// <returns></returns>
            public virtual string 读取当前频率()
            {
                return string.Format("SOUR:FREQ?");
            }

            /// <summary>
            /// 设置功率|POWer {0}
            /// </summary>
            /// <param name="value">50dbm</param>
            /// <returns></returns>
            public virtual string 设置功率(string value)
            {
                return string.Format("SOUR:POWer {0}", value);
            }

            /// <summary>
            /// 读取当前功率|POWer?
            /// </summary>
            /// <returns></returns>
            public virtual string 读取当前功率()
            {
                return string.Format("SOUR:POWer?");
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

    /// <summary>
    /// Keysight
    /// 
    /// 信号源-复合指令集方法
    /// </summary>
    public class SignalGeneratorSCPIBase_Keysight_Complex:SignalGeneratorSCPIBase_Keysight
    {
        public virtual string[] 设置频率和功率(string pinlv="50MHz",string gonglv="50dBm")
        {
            List<string> commands = new List<string>();
            commands.Add(SOURCE_SYSTEM.设置频率(pinlv));
            commands.Add(SOURCE_SYSTEM.设置功率(gonglv));
            return commands.ToArray();
        }
    }



}
