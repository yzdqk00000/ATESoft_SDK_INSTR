using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public enum 脉宽类型
    {
        _5μs = 5,
        _60μs = 60,
    }
    public enum 频率工作范围
    {
        F01 = 34900,
        F02 = 35000,
        F03 = 35100,
        F04 = 35200,
        F05 = 35300,
        F06 = 35400,
        F07 = 35500,
        F08 = 35600,
        F09 = 35700,
        F10 = 35800,
        F11 = 35900,
        F12 = 36000,
        F13 = 36100,
        F14 = 36200,
    }


    public class Test发射机测试基础
    {
        public Dictionary<频率工作范围,int> LX频率校准映射 = new Dictionary<频率工作范围, int>();
        public decimal L0信号源补偿 { get;set;} = 0m;
        public decimal L1功率计补偿 { get;set;} = 0m;
        public decimal L2频谱仪补偿 { get;set;}=0m;

        public decimal D占空比 = 10m;

        public SignalGeneratorBase _SignalGener;   
        public PowerMeterBase _PowerMeter;   
        public ControlModule _ControlModule;
        public WaveformGeneratorBase _WaveFormGenerator;
        
        public WaveformGeneratorSCPIBase_Rigol _SCPI_WaveForm= new WaveformGeneratorSCPIBase_Rigol();
        public PowerMeterSCPIBase_Keysight _SCPI_PowerMeter = new PowerMeterSCPIBase_Keysight();
        public SignalGeneratorSCPIBase_RS _SCPI_SignalGenerator = new SignalGeneratorSCPIBase_RS();
        
        public Test发射机测试基础(PowerMeterBase powermeter, SignalGeneratorBase signal,ControlModule control,WaveformGeneratorBase wave) 
        {
            _SignalGener = signal;
            _PowerMeter = powermeter;
            _ControlModule = control;
            _WaveFormGenerator = wave;
            int count = 0;
            foreach (频率工作范围 item in Enum.GetValues(typeof(频率工作范围)))
            {
                LX频率校准映射.Add(item, count++);
            }
        }

        public void 补偿设置(频率工作范围 freq)
        {
            //L0信号源补偿 = Convert.ToDecimal(Modules.ucJiaoZhun.CalibrationObjectList.Find(m => m.FileName == "XHY.prn").CalibrationData[LX频率校准映射[freq]]);
            L1功率计补偿 = Convert.ToDecimal(Modules.ucJiaoZhun.CalibrationObjectList.Find(m=>m.FileName == "GLJ.prn").CalibrationData[LX频率校准映射[freq]]);
            L2频谱仪补偿 = Convert.ToDecimal(Modules.ucJiaoZhun.CalibrationObjectList.Find(m => m.FileName == "PPY.prn").CalibrationData[LX频率校准映射[freq]]);
            //_SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置功率Offsets(L0信号源补偿.ToString()));
            //_SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置频率(string.Format("{0}MHz", (int)freq)));
            //_PowerMeter.VisaWrite(_SCPI_PowerMeter.SENSE_SYSTEM.设置增益DB补偿Offset(1, (-L1功率计补偿).ToString()));
        }

        public void 脉冲源基础设置(脉宽类型 pulseWidth,decimal dutyRadio)
        {
            dutyRadio = dutyRadio / 100;
            if (pulseWidth == 脉宽类型._60μs)
            {
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse周期设置(1, (60.7m / dutyRadio).ToString() + "us"));
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse周期设置(2, (60m / dutyRadio).ToString() + "us"));
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse脉宽设置(1, "60.7us"));
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse脉宽设置(2, "60us"));
            }
            else
            {
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse周期设置(1, (5.7m / dutyRadio).ToString() + "us"));
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse周期设置(2, (5m / dutyRadio).ToString() + "us"));
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse脉宽设置(1, "5.7us"));
                _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse脉宽设置(2, "5us"));
           
            }
        }

    }

    public class TestMapExcel
    {
        public string 输出峰值功率 { get;set;} = "B";
        public string 脉冲前沿 { get;set;} = "C";
        public string 脉冲后沿 { get; set; } = "D";
        public string 平顶降落 { get; set; } = "E";
        public string 带内起伏 { get; set; } = "F";
        public string 脉内信杂比 { get; set; } = "G";
        public string 功率控制P1 { get;set;} = "H";
        public string 功率控制P2 { get; set; } = "I";
        public Dictionary<频率工作范围,int> FreqMapExcel = new Dictionary<频率工作范围, int>();

        public TestMapExcel()
        {
            int rowOfExcel = 3;
            foreach (频率工作范围 item in Enum.GetValues(typeof(频率工作范围)))
            {
                FreqMapExcel.Add(item, rowOfExcel++);
            }
        }
    }
}
