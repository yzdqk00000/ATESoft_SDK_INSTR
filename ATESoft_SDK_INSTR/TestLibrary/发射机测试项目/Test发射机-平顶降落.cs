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
            补偿设置(freq);

            _ControlModule.SwitchControl(ControlModule.仪表选择.功率计);
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.CALC_SYSTEM.设置MeasureType(1, "1", PowerMeterSCPIBase_Keysight.CALCulate_System.MeasureType.PTAV));
              
            Thread.Sleep(20);//没有延时会读不到值
        }
        
        public double 功率计读取顶降值()
        {         
            //信号源设置输出频率(频率工作范围.F01);
            return _PowerMeter.VisaRead_double(_SCPI_PowerMeter.MEASUREMENT_SYSTEM.读取Fetch数值());            
        }
    }
}
