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
    public class Test发射机_脉冲前后沿: Test发射机测试基础
    {
        public const string TestName = "脉冲前后沿";

        public Test发射机_脉冲前后沿(PowerMeterBase powermeter, SignalGeneratorBase signal, ControlModule control, WaveformGeneratorBase wave) : base(powermeter, signal, control, wave)
        {
        }

        private void 脉冲源设置前后沿测量模式()
        {
            foreach (频率工作范围 item in Enum.GetValues(typeof(频率工作范围)))
            {
                Console.WriteLine((int)item);
            }
        }

        public double Get指标要求(频率工作范围 freq)
        {
            return 100;
        }

        public double 功率计读取脉冲前沿数值(频率工作范围 freq)
        {
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.TRIGGER_SYSTEM.设置Slope("POS"));
            Thread.Sleep(1000);
            return Math.Round(_PowerMeter.VisaRead_double(_SCPI_PowerMeter.SENSE_SYSTEM.读取脉冲前沿()) * 1000000000, 2);
        }
        public double 功率计读取脉冲后沿数值(频率工作范围 freq)
        {
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.TRIGGER_SYSTEM.设置Slope("NEG"));
            Thread.Sleep(1000);
            return Math.Round(_PowerMeter.VisaRead_double(_SCPI_PowerMeter.SENSE_SYSTEM.读取脉冲后沿()) * 1000000000, 2);
        }


        public void 该测试前设置(频率工作范围 freq,脉宽类型 pulseWidth,decimal dutyRadio)
        {
            补偿设置(freq);
            脉冲源基础设置(pulseWidth, dutyRadio);
            _ControlModule.SwitchControl(ControlModule.仪表选择.功率计);
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.CALC_SYSTEM.设置MeasureType(1, "1", PowerMeterSCPIBase_Keysight.CALCulate_System.MeasureType.AVER));
            if (pulseWidth == 脉宽类型._60μs)
            {
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Scale(1, "0.000008"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Start(1, "-0.000005"));
            }
            else
            {          
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Scale(1, "0.0000006"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_X_Start(1, "-0.000001"));
            }
            Thread.Sleep(3000);
        }
    }
}
