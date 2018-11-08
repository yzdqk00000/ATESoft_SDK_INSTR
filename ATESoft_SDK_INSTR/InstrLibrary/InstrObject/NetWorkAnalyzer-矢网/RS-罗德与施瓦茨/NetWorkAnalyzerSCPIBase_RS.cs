using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// CETC41
    /// 
    /// 矢量网络分析仪-SCPI指令
    /// </summary>
    public class NetWorkAnalyzerSCPIBase_RS : SCPIBase
    {
        public CALCulate_System CALC_SYSTEM = new CALCulate_System();
        public MEMMory_System MEMM_SYSTEM = new MEMMory_System();

        /// <summary>
        /// CALC指令系统
        /// </summary>
        public class CALCulate_System
        {
            /// <summary>
            /// 读取Mark的Y值CALC{0}:MARK{1}:Y?
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="mknum">MARK号</param>
            /// <returns></returns>
            public virtual string 读取Mark的Y值(int cnum=1,int mknum = 1)
            {
                return string.Format("CALC{0}:MARK{1}:Y?", cnum, mknum);
            }

            /// <summary>
            /// 设置Mark的X值CALC{0}:MARK{1}:X {2}
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="mknum">MARK号</param>
            /// <param name="freq">频率值</param>
            /// <returns></returns>
            public virtual string 设置Mark的X值(string freq,int cnum = 1, int mknum = 1)
            {
                return string.Format("CALC{0}:MARK{1}:X {2}", cnum, mknum,freq);
            }

            /// <summary>
            /// 设置测试显示格式CALC{0}:FORM {1}
            /// </summary>
            /// <param name="format">显示格式SWR,PHAS</param>
            /// <param name="cnum">通道号</param>
            /// <returns></returns>
            public virtual string 设置测试显示格式(string format="SWR", int cnum = 1)
            {
                return string.Format("CALC{0}:FORM {1}");
            }
        }

        /// <summary>
        /// MEMM指令系统
        /// </summary>
        public class MEMMory_System
        {
            /// <summary>
            /// 载入测试文件路径MMEM:LOAD '{0}'
            /// </summary>
            /// <param name="path">路径</param>
            /// <returns></returns>
            public virtual string 载入Memory(string path="MyFile.csa")
            {
                return string.Format("MMEM:LOAD '{0}'",path);
                
            }
        }
    }

    
}
