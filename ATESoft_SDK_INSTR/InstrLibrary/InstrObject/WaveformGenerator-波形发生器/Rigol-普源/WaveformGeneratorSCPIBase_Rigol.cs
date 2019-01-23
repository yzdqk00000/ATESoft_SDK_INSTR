using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 普源
    /// 
    /// 波形信号发生器-SCPI指令
    /// </summary>
    public class WaveformGeneratorSCPIBase_Rigol : SCPIBase
    {
        public OUTPut_System OUTPUT_SYSTEM = new OUTPut_System();
        public SOURce_System SOURCE_SYSTEM = new SOURce_System();

        /// <summary>
        /// OUTPut指令系统
        /// </summary>
        public class OUTPut_System
        {
            /// <summary>
            /// 打开关闭输出|OUTP{0} {1}
            /// </summary>
            /// <param name="state"></param>
            /// <returns></returns>
            public virtual string 开or关输出(int cnum = 1, string state = "OFF")
            {
                return string.Format("OUTP{0} {1}", cnum,state);
            }
        }

        /// <summary>
        /// Source指令系统
        /// </summary>
        public class SOURce_System
        {
            /// <summary>
            /// Pulse脉宽设置  SOUR{0}:PULSe:WIDTh {1}
            /// </summary>
            /// <param name="cnum">通道号 1</param>
            /// <param name="value">脉宽 0.5ms</param>
            /// <returns></returns>
            public virtual string Pulse脉宽设置(int cnum = 1, string value = "0.5ms")
            {
                return string.Format("SOUR{0}:PULSe:WIDTh {1}", cnum, value);
            }

            /// <summary>
            /// Pulse占空比设置  SOUR{0}:PULSe:DCYCle {1}
            /// </summary>
            /// <param name="cnum">通道号 1</param>
            /// <param name="value">value 50(%)</param>
            /// <returns></returns>
            public virtual string Pulse占空比设置(int cnum = 1, string value = "50")
            {
                return string.Format("SOUR{0}:PULSe:DCYCle {1}", cnum, value);
            }

            /// <summary>
            /// Pulse延时设置 SOUR{0}:PULS:DELay {1}
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="value">延时时间 单位ns|s|us等，也可直接传数值默认是s</param>
            /// <returns></returns>
            public virtual string Pulse延时设置(int cnum = 1, string value = "0ns")
            {
                return string.Format("SOUR{0}:PULS:DELay {1}", cnum, value);
            }

            /// <summary>
            /// Pulse周期设置 SOUR{0}:PER {1}
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="value">延时时间 单位ns|s|us等，也可直接传数值默认是s</param>
            /// <returns></returns>
            public virtual string Pulse周期设置(int cnum = 1, string value = "300us")
            {
                return string.Format("SOUR{0}:PER {1}", cnum, value);
            }

            /// <summary>
            /// Pulse上升沿时间设置 SOUR{0}:PULS:TRAN:LEAD {1}
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="value">时间</param>
            /// <returns></returns>
            public virtual string Pulse上升沿时间设置(int cnum = 1, string value = "4ns")
            {
                return string.Format("SOUR{0}:PULS:TRAN:LEAD {1}", cnum, value);
            }

            /// <summary>
            /// Pulse下降沿时间设置 SOUR{0}:PULS:TRAN:TRA {1}
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="value">时间</param>
            /// <returns></returns>
            public virtual string Pulse下降沿时间设置(int cnum = 1, string value = "4ns")
            {
                return string.Format("SOUR{0}:PULS:TRAN:TRA {1}", cnum, value);
            }


            /// <summary>
            /// Pulse频率_幅度_偏移_延时设置 SOURce{0}:APPL:PULS {1},{2},{3},{4}
            /// </summary>
            /// <param name="cnum">通道号 1</param>
            /// <param name="freq">频率 1000 （= 1KHz）</param>
            /// <param name="amp">幅度 5 （Vpp）</param>
            /// <param name="offset">偏移 0 （vcc）</param>
            /// <param name="delay">延时 0（ns）</param>
            /// <returns></returns>
            public virtual string Pulse频率_幅度_偏移_延时设置(int cnum = 1, string freq = "1000",string amp="5",string offset="0",string delay="0")
            {
                return string.Format("SOURce{0}:APPL:PULS {1},{2},{3},{4}", cnum, freq, amp, offset, delay);
            }

  
            /// <summary>
            /// Voltage高电平设置  SOUR{0}:VOLT:HIGH {1}
            /// </summary>
            /// <param name="cnum">通道号 1|2</param>
            /// <param name="value">电压数值 单位（V）</param>
            /// <returns></returns>
            public virtual string Voltage高电平设置(int cnum = 1,string value="5")
            {
                return string.Format("SOUR{0}:VOLT:HIGH {1}", cnum, value);
            }

            /// <summary>
            /// Voltage低电平设置 SOUR{0}:VOLT:LOW {1}
            /// </summary>
            /// <param name="cnum">通道号 1|2</param>
            /// <param name="value">电压数值 单位（V）</param>
            /// <returns></returns>
            public virtual string Voltage低电平设置(int cnum = 1, string value = "0")
            {
                return string.Format("SOUR{0}:VOLT:LOW {1}", cnum, value);
            }

            
        }
    }

    
}
