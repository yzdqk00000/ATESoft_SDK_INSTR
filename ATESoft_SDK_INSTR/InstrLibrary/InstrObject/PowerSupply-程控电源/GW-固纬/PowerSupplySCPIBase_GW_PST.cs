using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrLibrary.InstrObect
{
    public class PowerSupplySCPIBase_GW_PST
    {
        public SOURce_System SOURCE_SYSTEM = new SOURce_System();
        public OUTPut_System OUTPUT_SYSTEM = new OUTPut_System();
        public class SOURce_System
        {
            /// <summary>
            /// 设置电压值
            /// </summary>
            /// <param name="cnum"></param>
            /// <returns></returns>
            public virtual string 设置电压值(int ch, string value)
            {
                return string.Format("CHAN{0}:VOLT {1}", ch,value);
            }

            /// <summary>
            /// 设置电流值
            /// </summary>
            /// <param name="cnum"></param>
            /// <returns></returns>
            public virtual string 设置电流值(int ch,string value)
            {
                return string.Format("CHAN{0}:CURR {1}", ch,value);
            }

            /// <summary>
            /// 读取测试电流值
            /// </summary>
            /// <param name="ch"></param>
            /// <returns></returns>
            public virtual string 读取测试电流值(int ch)
            {
                return string.Format("CHAN{0}:MEAS:CURR?", ch);
            }

            /// <summary>
            /// 读取测试电压值
            /// </summary>
            /// <param name="ch"></param>
            /// <returns></returns>
            public virtual string 读取测试电压值(int ch)
            {
                return string.Format("CHAN{0}:MEAS:VOLT?", ch);
            }
        }

        public class OUTPut_System
        {
            /// <summary>
            /// 开or关输出 OUTP:STAT {0}
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 开or关输出(int value)
            {
                return string.Format("OUTP:STAT {0}", value);
            }

            /// <summary>
            /// 设置输出Track模式
            /// VALUE = 0 : indepentent模式
            /// VALUE = 1 : parrell
            /// VALUE = 2:  Serials模式
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public virtual string 设置输出Track模式(int value)
            {
                return string.Format("OUTP:COUP:TRAC {0}", value);
            }
        }
    }
}
