using InstrLibrary.InstrDriver;
using System.Collections.Generic;

namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 是德科技-Keysight
    /// 
    /// 矢量网络分析仪-SCPI常用指令
    /// </summary>
    public class NetWorkAnalyzerSCPIBase_Keysight : SCPIBase
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

    /// <summary>
    /// 复杂指令集合
    /// 
    /// 连环发送多条指令
    /// </summary>
    public class NetWorkAnalyzerSCPI_Keysight_Complex: NetWorkAnalyzerSCPIBase_Keysight
    {
        /// <summary>
        /// 例：连续设置多个MARK点
        /// </summary>
        /// <returns></returns>
        public string[] 连续设置5个不同的Mark()
        {
            List<string> commands = new List<string>();
            commands.Add(this.CALC_SYSTEM.设置Mark的X值("50MHz", 1, 1));
            commands.Add(this.CALC_SYSTEM.设置Mark的X值("100MHz", 1, 2));
            commands.Add(this.CALC_SYSTEM.设置Mark的X值("150MHz", 1, 3));
            commands.Add(this.CALC_SYSTEM.设置Mark的X值("160MHz", 1, 4));
            commands.Add(this.CALC_SYSTEM.设置Mark的X值("180MHz", 1, 5));
            return commands.ToArray();
        }
    }
}
