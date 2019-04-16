using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrLibrary.InstrObect;
using System.Diagnostics;
using System.Threading;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class Test发射机_输出峰值功率 : Test发射机测试基础
    {
        public const string TestName = "输出峰值功率";
        public Test发射机_输出峰值功率(PowerMeterBase powermeter, SignalGeneratorBase signal, ControlModule control,WaveformGeneratorBase wave):base(powermeter,signal,control,wave)
        {

        }

        public 脉宽类型 发射信号脉冲宽度 = 脉宽类型._5μs;
        public double Get指标要求(频率工作范围 freq)
        {
            if ((int)freq <= (int)频率工作范围.F05)
                return 45;
            else           
                return 50;        
        }

        public double 功率计读取峰值功率(频率工作范围 freq, 脉宽类型 pulseWidth)
        {
            补偿设置(freq);
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置Freq((int)freq + "MHz"));
            if (pulseWidth == 脉宽类型._60μs)
            {
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Scale(1, "0.00001"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Start(1, "-0.00003"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置GateSetup_MARK1_TIME(1, 1, "6us"));
            }
            else
            {                
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Scale(1, "0.0000008"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Start(1, "-0.000001"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置GateSetup_MARK1_TIME(1, 1, "700ns"));
            }
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_AutoScale());
            Thread.Sleep(1000);
            return Math.Round(_PowerMeter.VisaRead_double(_SCPI_PowerMeter.MEASUREMENT_SYSTEM.读取Fetch数值(2)) , 2);
        }

        public void 该测试前设置(频率工作范围 freq, 脉宽类型 pulseWidth,decimal dutyRadio)
        {
            脉冲源基础设置(pulseWidth, dutyRadio);
            
            _ControlModule.SwitchControl(ControlModule.仪表选择.功率计);
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.CALC_SYSTEM.设置MeasureType(1, "1", PowerMeterSCPIBase_Keysight.CALCulate_System.MeasureType.PEAK));
         
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.UNIT_SYSTEM.设置UNIT(2, "W"));
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_Unit(1,"W"));
            Thread.Sleep(2000);
        }
    }
}
