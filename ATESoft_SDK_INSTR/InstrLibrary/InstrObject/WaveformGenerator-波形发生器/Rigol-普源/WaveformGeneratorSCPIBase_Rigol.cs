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
        public MEMMory_System MEMMORY_SYSTEM = new MEMMory_System();

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

        public class SOURce_System
        {

        }

        public class MEMMory_System
        {

        }
    }

    
}
