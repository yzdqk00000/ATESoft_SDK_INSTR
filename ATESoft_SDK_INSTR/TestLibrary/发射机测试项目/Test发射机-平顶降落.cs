using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class Test发射机_平顶降落 : Test发射机测试基础
    {
        public const string TestName = "平顶降落";

        public Test发射机_平顶降落(PowerMeterBase powermeter, SignalGeneratorBase signal, ControlModule control, WaveformGeneratorBase wave) : base(powermeter, signal, control, wave)
        {

        }

        public void 开关切换_功率计()
        {
            _ControlModule.SwitchControl(ControlModule.仪表选择.功率计);
        }

        public double Get指标要求(频率工作范围 freq)
        {
            return 0.5;
        }

        public void 该测试前设置(频率工作范围 freq, 脉宽类型 pulseWidth,decimal dutyRadio)
        {
            脉冲源基础设置(pulseWidth, dutyRadio);
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.SYSTEM_SYSTEM.PRESET模式("RADar"));
            Thread.Sleep(2800);
            _ControlModule.SwitchControl(ControlModule.仪表选择.功率计);
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.CALC_SYSTEM.设置MeasureType(1, "1", PowerMeterSCPIBase_Keysight.CALCulate_System.MeasureType.PTAV));
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.UNIT_SYSTEM.设置UNIT(2, "DBM"));
            if (pulseWidth == 脉宽类型._60μs)
            {
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置GateSetup_MARK1_TIME(1, 1, "6us"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置GateSetup_MARK1到MARK2_TIME(1, 1, "48us"));
            }
            else
            {
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置GateSetup_MARK1_TIME(1, 1, "0.5us"));
                _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置GateSetup_MARK1到MARK2_TIME(1, 1, "4us"));
            }
            Thread.Sleep(2000);
        }
        
        public double 功率计读取顶降值(频率工作范围 freq)
        {
            补偿设置(freq);
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置TraceSetup_AutoScale());

            Thread.Sleep(2500);//等待AutoScale时间
            double _P1 = Convert.ToDouble(_PowerMeter.VisaRead_double(_SCPI_PowerMeter.SENSE_SYSTEM.读取GateSetup_MARK_POW(1, 1, 1)));
            Thread.Sleep(200);
            double _P2 = Convert.ToDouble(_PowerMeter.VisaRead_double(_SCPI_PowerMeter.SENSE_SYSTEM.读取GateSetup_MARK_POW(1, 1, 2)));
            return Math.Round(_P1-_P2,2);            
        }
    }
}
