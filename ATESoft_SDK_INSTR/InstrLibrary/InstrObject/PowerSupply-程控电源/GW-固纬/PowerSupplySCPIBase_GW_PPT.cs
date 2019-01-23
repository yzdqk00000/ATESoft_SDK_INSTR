using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 固纬PPT系列
    /// 
    /// 电源-SCPI指令
    /// </summary>
    public class PowerSupplySCPIBase_GW_PPT : SCPIBase
    {
        public OUTPut_System OUTPUT_SYSTEM = new OUTPut_System();
        public SOURce_System SOURCE_SYSTEM = new SOURce_System();

        public class SOURce_System
        {

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual string 读取电流值()
            {
                return string.Format("CURR?");
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual string 读取电压值()
            {
                return string.Format("VOLT?");
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cnum"></param>
            /// <returns></returns>
            public virtual string 设置电压值(string value)
            {
                return string.Format("VOLT {0}",value);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cnum"></param>
            /// <returns></returns>
            public virtual string 设置电流值(string value)
            {
                return string.Format("CURR {0}", value);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cnum"></param>
            /// <returns></returns>
            public virtual string 选择通道(int cnum)
            {
                return string.Format("CHAN {0}",cnum);
            }
        }

        public class OUTPut_System
        {
            /// <summary>
            /// OUTP
            /// </summary>
            /// <param name="state"></param>
            /// <returns></returns>
            public virtual string 输出开关(string state = "OFF")
            {
                return string.Format("OUTP:STAT {0}" ,state);
            }
        }
    }

    
}
