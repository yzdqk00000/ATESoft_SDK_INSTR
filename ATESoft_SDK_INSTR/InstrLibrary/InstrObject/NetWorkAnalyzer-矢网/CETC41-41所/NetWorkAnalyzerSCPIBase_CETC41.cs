using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// CETC41
    /// 
    /// 矢量网络分析仪-SCPI指令
    /// </summary>
    public class NetWorkAnalyzerSCPIBase_CETC41 : SCPIBase
    {
        public CALCulate_System CALC_SYSTEM = new CALCulate_System();
        public MEMMory_System MEMM_SYSTEM = new MEMMory_System();
        public SENSe_System SENS_SYSTEM = new SENSe_System();

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
                return string.Format("CALC{0}:FORM {1}",cnum,format);
            }

            /// <summary>
            /// 选择测试根据名称|CALC{0}:PAR:SEL '{1}'
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="name">测试名称</param>
            /// <returns></returns>
            public virtual string 选择测试窗口根据名称(int cnum = 1, string name = "CH1_S11_1")
            {
                return string.Format("CALC{0}:PAR:SEL '{1}'", cnum, name);
            }

            /// <summary>
            /// CALC{0}:MARK{1} ON
            /// </summary>
            /// <param name="cnum"></param>
            /// <param name="name"></param>
            /// <returns></returns>
            public virtual string 打开MARK点(int cnum = 1, int name = 1)
            {
                return string.Format("CALC{0}:MARK{1} ON", cnum, name);
            }
        }

        public class SENSe_System
        {
            /// <summary>
            /// SENS:FREQ:STAR {1}MHz
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 设置起始频率(string value)
            {
                return string.Format("SENS:FREQ:STAR {1}MHz", value);
            }

            /// <summary>
            /// SENS:FREQ:STOP {1}MHz
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 设置终止频率(string value)
            {
                return string.Format("SENS:FREQ:STOP {1}MHz", value);
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
