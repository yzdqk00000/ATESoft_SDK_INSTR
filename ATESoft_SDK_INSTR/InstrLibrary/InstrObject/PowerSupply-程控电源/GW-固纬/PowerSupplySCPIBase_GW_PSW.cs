using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 固纬PSW系列
    /// 
    /// 电源-SCPI指令
    /// </summary>
    public class PowerSupplySCPIBase_GW_PSW : SCPIBase
    {
        public MEASure_System MEASURE_SYSTEM = new MEASure_System();
        public OUTPut_System OUTPUT_SYSTEM = new OUTPut_System();
        public class MEASure_System
        {

            /// <summary>
            /// MEAS:CURR?
            /// </summary>
            /// <returns></returns>
            public virtual string 读取电流值()
            {
                return string.Format("MEAS:CURR?");
            }

            /// <summary>
            /// MEAS:VOLT?
            /// </summary>
            /// <returns></returns>
            public virtual string 读取电压值()
            {
                return string.Format("MEAS:VOLT?");
            }

            /// <summary>
            /// VOLT
            /// </summary>
            /// <returns></returns>
            public virtual string 设置电压值(double value)
            {
                return string.Format("VOLT " + value);
            }

            /// <summary>
            /// CURR
            /// </summary>
            /// <returns></returns>
            public virtual string 设置电流值(double value)
            {
                return string.Format("CURR " +value);
            }
        }
        public class OUTPut_System
        {
            /// <summary>
            /// OUTP
            /// </summary>
            /// <param name="state"></param>
            /// <returns></returns>
            public virtual string 输出开关(int state=1)
            {
                return string.Format("OUTP " +state);
            }
        }
    }
     
}
