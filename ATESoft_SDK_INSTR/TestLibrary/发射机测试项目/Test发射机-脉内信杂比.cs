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
        //算法1
        //public double 读取脉内信杂比(频率工作范围 freq)
        //{
        //    补偿设置(freq);

        //     _Spec.VisaWrite(_SCPI_Spec.SENSE_SYSTEM.设置中心频率center((int)freq+"MHz"));
        //    _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
        //    Thread.Sleep(500);
        //    int mainSignalCountInSpan = 4;

        //    int noiseGettingCountInSpan = 100;
        //    List<double> noiseList = new List<double>();

        //    List<double> maxList = new List<double>();
        //    _Spec.VisaWrite(_SCPI_Spec.CALC_SYSTEM.设置MARK最大MAX(1));

        //    double maxValue = _Spec.VisaRead_double(_SCPI_Spec.CALC_SYSTEM.读取MARK点(1)) - Convert.ToDouble(L2频谱仪补偿);
        //    for (int i = 1; i < mainSignalCountInSpan; i++)
        //    {
        //        _Spec.VisaWrite(_SCPI_Spec.CALC_SYSTEM.设置MARK次峰MAX_NEXT(1));
        //        maxList.Add(_Spec.VisaRead_double(_SCPI_Spec.CALC_SYSTEM.读取MARK点(1)) - Convert.ToDouble(L2频谱仪补偿));
        //    }
        //    maxValue = maxList.Average();

        //    for (int i = 0; i < noiseGettingCountInSpan; i++)
        //    {
        //        _Spec.VisaWrite(_SCPI_Spec.CALC_SYSTEM.设置MARK次峰MAX_NEXT(1));
        //        Thread.Sleep(20);
        //        noiseList.Add(_Spec.VisaRead_double(_SCPI_Spec.CALC_SYSTEM.读取MARK点(1)));
        //    }
        //    double noiseAverage = noiseList.Average() - Convert.ToDouble(L2频谱仪补偿);             
        //    double res = maxValue- noiseAverage;
        //    Thread.Sleep(1200);
        //    return res;
        //}
        //算法2
        public double 读取脉内信杂比(频率工作范围 freq)
        {
            补偿设置(freq);

            _Spec.VisaWrite(_SCPI_Spec.SENSE_SYSTEM.设置中心频率center((int)freq + "MHz"));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率((int)freq + "MHz"));
            Thread.Sleep(1000);
            int mainSignalCountInSpan = 4;
            List<double> noiseList = new List<double>();
            List<double> maxList = new List<double>();

            noiseList.AddRange(_Spec.VisaReads(_SCPI_Spec.CALC_SYSTEM.读取所有Y值()));

            for (int i = 0; i < mainSignalCountInSpan; i++)
            {
                maxList.Add(noiseList.Max());
                noiseList.Remove(noiseList.Max());
            }

            double noiseAvg;
            if (noiseList.Count != 0)
                noiseAvg = noiseList.Where(M => M < -90).Average();
            else
                return 0;

            double noiseRes = noiseAvg;
            double res = maxList.Average() - noiseRes;
            //Thread.Sleep(1200);
            return Math.Round(res, 2);
        }
        public void 该测试前设置(频率工作范围 freq,脉宽类型 pulseWidth,decimal dutyRadio)
        {
            脉冲源基础设置(pulseWidth,dutyRadio);
            _ControlModule.SwitchControl(ControlModule.仪表选择.频谱仪);
            _Spec.VisaWrite(_SCPI_Spec.SYSTEM_SYSTEM.程控时保持显示());
            _Spec.VisaWrite(_SCPI_Spec.DISPLAY_SYSTEM.设置参考电平("1", "-10"));
          
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
