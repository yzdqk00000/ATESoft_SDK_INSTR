using InstrLibrary.InstrDriver;
using System;

namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// Keysight
    /// 
    /// 功率计-SCPI指令
    /// </summary>
    public class PowerMeterSCPIBase_Keysight : SCPIBase
    {
        public CALCulate_System CALC_SYSTEM = new CALCulate_System();
        public MEASurement_System MEASUREMENT_SYSTEM = new MEASurement_System();
        public SENSe_System SENSE_SYSTEM = new SENSe_System();
        public SYSTem_System SYSTEM_SYSTEM = new SYSTem_System();
        public class SYSTem_System
        {
            public virtual string PRESET模式(string mode)
            {
                return string.Format("SYST:PRES {0}", mode);
            }
        }
        /// <summary>
        /// CALC指令系统
        /// </summary>
        public class CALCulate_System
        {
            /// <summary>
            /// 设置MeasureType
            /// </summary>
            /// <param name="calcBlock">计算块</param>
            /// <param name="feedNumber"> FEED的编号，MEASURE中可查看</param>
            /// <param name="type">测量模式</param>
            /// <returns></returns>
            public enum MeasureType { PEAK, AVER, PTAV, MIN }
            public virtual string 设置MeasureType(int calcBlock = 1, string feedNumber = "1", MeasureType type = MeasureType.AVER)
            {
                return string.Format("CALC{0}:FEED{1} 'POW:{2}'", calcBlock, feedNumber, Enum.GetName(type.GetType(), type));
            }
        }

        /// <summary>
        /// MEASurement指令系统
        /// </summary>
        public class MEASurement_System
        {
            /// <summary>
            /// 读取功率计上显示的值
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <returns></returns>
            public virtual string 读取Fetch数值(int channel = 1)
            {
                return string.Format("FETC{0}?", channel);
            }
        }

        /// <summary>
        /// SENSE指令系统
        /// </summary>
        public class SENSe_System
        {
            /// <summary>
            /// 设置增益DB补偿Offset SENS{0}:CORR:GAIN2 {1}
            /// 注意：这里的GAIN2表示的是OFFSET补偿，如果写成GAIN1就变成Calibration校准的参数了。
            /// </summary>
            /// <param name="channel">通道号，屏幕上的A和B</param>
            /// <param name="db">补偿值，单位自动是db不要加单位</param>
            /// <returns></returns>
            public virtual string 设置增益DB补偿Offset(int channel=1,string db="-10")
            {
                return string.Format("SENS{0}:CORR:GAIN2 {1}", channel,db);
            }

            /// <summary>
            /// 读取脉冲前沿
            /// </summary>
            /// <returns></returns>
            public virtual string 读取脉冲前沿()
            {
                return string.Format("TRAC:MEAS:TRAN:POS:DUR?");
            }
            
            /// <summary>
            /// 读取脉冲后沿
            /// </summary>
            /// <returns></returns>
            public virtual string 读取脉冲后沿()
            {
                return string.Format("TRAC:MEAS:TRAN:NEG:DUR?");
            }

            /// <summary>
            /// 开or关增益DB补偿Offset SENS{0}:CORR:GAIN2:STAT {1}
            /// </summary>
            /// <param name="channel">通道号，屏幕上的A和B</param>
            /// <param name="state">ON|OFF</param>
            /// <returns></returns>
            public virtual string 开or关增益DB补偿Offset(int channel = 1, string state = "ON")
            {
                return string.Format("SENS{0}:CORR:GAIN2:STAT {1}", channel, state);
            }

            /// <summary>
            /// AutoScale，在屏幕的Channel，TraceSetup里
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <returns></returns>
            public virtual string 设置TraceSetup_AutoScale(int channel = 1)
            {
                return string.Format("SENS{0}:TRAC:AUT", channel);
            }

            /// <summary>
            /// 设置X-start
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <returns></returns>
            public virtual string 设置TraceSetup_X_Start(int channel = 1,string time="-250ns")
            {
                return string.Format("SENS{0}:TRAC:OFFS:TIME {1}", channel,time);
            }

            /// <summary>
            /// 读取X_Start
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <returns></returns>
            public virtual string 读取TraceSetup_X_Start(int channel = 1)
            {
                return string.Format("SENS{0}:TRAC:OFFS:TIME?", channel);
            }

            /// <summary>
            /// 设置TraceSetup_X_Scale 默认150ns
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <returns></returns>
            public virtual string 设置TraceSetup_X_Scale(int channel = 1,string time= "0.00000015")
            {
                return string.Format("SENS{0}:TRAC:X:SCAL:PDIV {1}", channel,time);
            }

            /// <summary>
            /// 设置TraceSetup_Y_Scale 根据显示单位,默认DB
            /// </summary>
            /// <param name="channel"></param>
            /// <param name="pow"></param>
            /// <returns></returns>
            public virtual string 设置TraceSetup_Y_Scale(int channel = 1, string pow = "7")
            {
                return string.Format("SENS{0}:TRAC:Y:SCAL:PDIV {1}", channel,pow);
            }

            /// <summary>
            /// 设置TraceSetup_Y_Max，根据单位，默认db,设置这个时，SCALE会发生同比例变化
            /// </summary>
            /// <param name="channel"></param>
            /// <param name="pow"></param>
            /// <returns></returns>
            public virtual string 设置TraceSetup_Y_Max(int channel = 1, string pow = "20")
            {
                return string.Format("SENS{0}:TRAC:LIM:UPP {1}", channel, pow);
            }

            /// <summary>
            /// 设置TraceSetup_Unit显示单位
            /// </summary>
            /// <param name="channel"></param>
            /// <param name="unit">两种单位 DBM | W</param>
            /// <returns></returns>
            public virtual string 设置TraceSetup_Unit(int channel = 1, string unit = "DBM")
            {
                return string.Format("SENS{0}:TRAC:UNIT {1}", channel, unit);
            }

            /// <summary>
            /// 读取通道1的GATE1的MARK1的值
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <param name="gatenum">GATE号</param>
            /// <param name="mknum">MARK号</param>
            /// <returns></returns>
            public virtual string 读取GateSetup_MARK_POW(int channel = 1, int gatenum = 1,int mknum =1)
            {
                return string.Format("SENS{0}:SWE{1}:MARK{2}:POW?", channel, gatenum,mknum);
            }

            /// <summary>
            /// 读取通道1GATE1MARK1的时间
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <param name="gatenum">GATE号</param>
            /// <returns></returns>
            public virtual string 读取GateSetup_MARK1_TIME(int channel = 1, int gatenum = 1)
            {
                return string.Format("SENS{0}:SWE{1}:OFFS:TIME?", channel, gatenum);
            }

            /// <summary>
            /// .将MARK1设置到5ns位置
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <param name="gatenum">GATE号</param>
            /// <param name="time">时间</param>
            /// <returns></returns>
            public virtual string 设置GateSetup_MARK1_TIME(int channel = 1, int gatenum = 1,string time="5ns")
            {
                return string.Format("SENS{0}:SWE{1}:OFFS:TIME {2}", channel, gatenum,time);
            }

            /// <summary>
            /// 读取GateSetup_MARK1到MARK2_TIME 
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <param name="gatenum">GATE号</param>
            /// <returns></returns>
            public virtual string 读取GateSetup_MARK1到MARK2_TIME(int channel = 1, int gatenum = 1)
            {
                return string.Format("SENS{0}:SWE{1}:TIME?", channel, gatenum);
            }

            /// <summary>
            /// 设置GateSetup_MARK1到MARK2_TIME 
            /// </summary>
            /// <param name="channel">通道号</param>
            /// <param name="gatenum">GATE号</param>
            /// <param name="time">MARK与MARK2间隔的时间</param>
            /// <returns></returns>
            public virtual string 设置GateSetup_MARK1到MARK2_TIME(int channel = 1, int gatenum = 1,string time="900ns")
            {
                return string.Format("SENS{0}:SWE{1}:TIME {2}", channel, gatenum,time);
            }
        }
    }

    
}
