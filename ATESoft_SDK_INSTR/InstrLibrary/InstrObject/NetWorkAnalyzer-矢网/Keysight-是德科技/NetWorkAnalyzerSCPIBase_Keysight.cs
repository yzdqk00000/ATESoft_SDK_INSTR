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
        public OUTPut_System OUTP_SYSTEM = new OUTPut_System();
        public SENSse_System SENS_SYSTEM = new SENSse_System();

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

            /// <summary>
            /// 打开/关闭MARK点|CALC{0}:MARK{1} {2}
            /// </summary>
            /// <param name="op">ON或OFF</param>
            /// <param name="cnum">通道号</param>
            /// <param name="mknum">MARK号</param>
            /// <returns></returns>
            public virtual string 开or关Mark点( string op = "ON",int cnum=1, int mknum = 1)
            {
                return string.Format("CALC{0}:MARK{1} {2}",cnum, mknum, op);
            }

            /// <summary>
            /// Returns the names and parameters of existing measurements for the specified channel|CALC{0}:PAR:CAT?
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <returns></returns>
            public virtual string 读取所有测试名称Catalog(int cnum = 1)
            {
                return string.Format("CALC{0}:PAR:CAT?", cnum);
            }

            /// <summary>
            /// 选择测试根据名称|CALC{0}:PAR:SEL '{1}'
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="name">测试名称</param>
            /// <returns></returns>
            public virtual string 选择测试窗口根据名称(int cnum=1,string name="CH1_S11_1")
            {
                return string.Format("CALC{0}:PAR:SEL '{1}'", cnum,name);
            }

            /// <summary>
            /// 读取曲线上的点
            /// </summary>
            /// <param name="cnum">通道号</param>
            /// <param name="style">类型，常用的是FDATA</param>
            ///For Measurement data, use FDATA or SDATA
            ///For Memory data, use FMEM or SMEM.When querying memory, you must first store a trace into memory using CALC:MATH:MEMorize.
            ///For Normalization Divisor(Receiver Power Cal error term) data, use SDIV
            ///Use FORMat:DATA to change the data type(<REAL,32>, <REAL,64> or<ASCii,0>).
            ///Use FORMat:BORDer to change the byte order.Use “NORMal” when transferring a binary block from LabView or Vee.For other programming languages, you may need to "SWAP" the byte order.
            /// <returns></returns>
            public virtual string 读取曲线点的数据(int cnum=1,string style="FDATA")
            {
                return string.Format("CALC{0}:DATA? {1}",cnum,style);
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

            /// <summary>
            /// 保存文件
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public virtual string 保存Memory(string path = "MyFile.csa")
            {
                return string.Format("MMEM:STOR '{0}'", path);
            }
        }

        /// <summary>
        /// OUTPUT指令系统
        /// </summary>
        public class OUTPut_System
        {
            /// <summary>
            /// 打开关闭源|OUTP {0}
            /// </summary>
            /// <param name="state"></param>
            /// <returns></returns>
            public virtual string 开or关输出(string state="OFF")
            {
                return string.Format("OUTP {0}",state);
            }
        }

        /// <summary>
        /// SENSE指令系统
        /// </summary>
        public class SENSse_System
        {
            /// <summary>
            /// 设置起始频率|SENS:FREQ:STAR {0}
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 设置起始频率(string value)
            {
                return string.Format("SENS:FREQ:STAR {0}",value);
            }

            /// <summary>
            /// 设置带宽SPAN|SENS:FREQ:SPAN {0}
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 设置带宽SPAN(string value="50MHz")
            {
                return string.Format("SENS:FREQ:SPAN {0}", value);
            }

            /// <summary>
            /// 设置终止频率|SENS:FREQ:STOP {0}
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 设置终止频率(string value)
            {
                return string.Format("SENS:FREQ:STOP {0}", value);
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
