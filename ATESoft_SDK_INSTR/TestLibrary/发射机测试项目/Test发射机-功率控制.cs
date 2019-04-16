using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class Test发射机_功率控制:Test发射机测试基础
    {
        public const string TestName = "功率控制测试";

        SpectrumAnalyzerBase _Spec;

        SpectrumAnalyzerSCPIBase_RS _SCPI_SPEC = new SpectrumAnalyzerSCPIBase_RS();

        public Test发射机_功率控制(PowerMeterBase powermeter, SignalGeneratorBase signal, ControlModule control, WaveformGeneratorBase wave,SpectrumAnalyzerBase spe) : base(powermeter, signal, control, wave)
        {
            _Spec = spe;
        }

        public double Start(频率工作范围 freq,ControlModule.功率控制 control)
        {
            补偿设置(freq);

            _ControlModule.PowerControl(control);
           
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
            _Spec.VisaWrite(_SCPI_SPEC.SENSE_SYSTEM.设置中心频率center((int)freq+"MHz"));
            Thread.Sleep(300);
            _Spec.VisaWrite(_SCPI_SPEC.CALC_SYSTEM.设置MARK最大MAX(1));
            Thread.Sleep(300);
            return Math.Round(_Spec.VisaRead_double(_SCPI_SPEC.CALC_SYSTEM.读取MARK点(1)), 2);
        }

        public void 该测试前设置(频率工作范围 freq,脉宽类型 pulseWidth,decimal dutyRadio)
        {
            _Spec.VisaWrite("*RST");

            脉冲源基础设置(pulseWidth,dutyRadio);
 
            _ControlModule.SwitchControl(ControlModule.仪表选择.频谱仪);
            _Spec.VisaWrite(_SCPI_SPEC.SYSTEM_SYSTEM.程控时保持显示());
            _Spec.VisaWrite(_SCPI_SPEC.DISPLAY_SYSTEM.设置参考电平("1", "14"));
           
            if (pulseWidth == 脉宽类型._5μs)
                _Spec.VisaWrite(_SCPI_SPEC.SENSE_SYSTEM.设置Span("160KHz"));
            else
                _Spec.VisaWrite(_SCPI_SPEC.SENSE_SYSTEM.设置Span("13.3KHz"));

            Thread.Sleep(2000);
        }
    }
}
