using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class Test发射机_脉内信杂比 : Test发射机测试基础
    {
        public const string TestName = "脉内信杂比";

        SpectrumAnalyzerSCPIBase_RS _SCPI_Spec = new SpectrumAnalyzerSCPIBase_RS();
        SpectrumAnalyzerBase _Spec;

        public Test发射机_脉内信杂比(PowerMeterBase powermeter, SignalGeneratorBase signal,SpectrumAnalyzerBase spe, ControlModule control, WaveformGeneratorBase wave) : base(powermeter, signal, control, wave)
        {
            _Spec = spe;
        }

        public double Get指标要求(频率工作范围 freq)
        {
            return 50;
        }

        //算法2
        public double 读取脉内信杂比(频率工作范围 freq)
        {
            补偿设置(freq);

            _Spec.VisaWrite(_SCPI_Spec.SENSE_SYSTEM.设置中心频率center((int)freq + "MHz"));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
            Thread.Sleep(500);
            int mainSignalCountInSpan = 4;
            List<double> noiseList = new List<double>();
            List<double> maxList = new List<double>();

            double[] resAllY = _Spec.VisaReads(_SCPI_Spec.CALC_SYSTEM.读取所有Y值());
            if(resAllY!=null && resAllY.Length!=0)
                noiseList.AddRange(resAllY);
            else
                return 0;

            for (int i = 0; i < mainSignalCountInSpan; i++)
            {
                maxList.Add(noiseList.Max());
                noiseList.Remove(noiseList.Max());
            }

            double noiseAvg;
            if (noiseList.Where(M => M < -60).Count() != 0)
                noiseAvg = noiseList.Where(M => M < -60).Average();
            else
                return 0;

            double res = maxList.Average() - noiseAvg;

            return Math.Round(res, 2);
        }
        public void 该测试前设置(频率工作范围 freq,脉宽类型 pulseWidth,decimal dutyRadio)
        {          
            脉冲源基础设置(pulseWidth,dutyRadio);
            _ControlModule.SwitchControl(ControlModule.仪表选择.频谱仪);
            _Spec.VisaWrite(_SCPI_Spec.SYSTEM_SYSTEM.程控时保持显示());
            _Spec.VisaWrite(_SCPI_Spec.DISPLAY_SYSTEM.设置参考电平("1", "10"));
          
            if (pulseWidth == 脉宽类型._5μs)          
                _Spec.VisaWrite(_SCPI_Spec.SENSE_SYSTEM.设置Span("160KHz"));           
            else          
                _Spec.VisaWrite(_SCPI_Spec.SENSE_SYSTEM.设置Span("13.3KHz"));                     
            _Spec.VisaWrite(_SCPI_Spec.SENSE_SYSTEM.设置RBW("10Hz"));
            _Spec.VisaWrite(_SCPI_Spec.SENSE_SYSTEM.设置VBW("1Hz"));

            Thread.Sleep(1200);
        }
    }
}
