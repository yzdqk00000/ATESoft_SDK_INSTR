using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class Test测试前后开机与关机: Test发射机测试基础
    {
        public class TestConfig
        {
            public string PSW_V = "0";
            public string PPT_V_CH1 = "0";
            public string PPT_V_CH2 = "0";
            public string PPT_V_CH3 = "0";
            public string PSW_OUTPUT = "ON";
            public string SignalSource_DBM = "2.5";
        }

        PowerSupplyBase _PowerSupply_PSW;
        PowerSupplyBase _PowerSupply_PPT;

        PowerSupplySCPIBase_GW_PSW _SCPI_PSW = new PowerSupplySCPIBase_GW_PSW();
        PowerSupplySCPIBase_GW_PPT _SCPI_PPT = new PowerSupplySCPIBase_GW_PPT();

        public Test测试前后开机与关机(PowerMeterBase powermeter, SignalGeneratorBase signal, ControlModule control, WaveformGeneratorBase wave,PowerSupplyBase power_ppt, PowerSupplyBase power_psw) : base(powermeter, signal, control, wave)
        {
            _PowerSupply_PSW = power_psw;
            _PowerSupply_PPT = power_ppt;
        }
        public TestConfig _TestConfigs { get;set;} = new TestConfig();

        public void ON()
        {
            _PowerSupply_PSW.VisaWrite(_SCPI_PSW.MEASURE_SYSTEM.设置电压值(_TestConfigs.PSW_OUTPUT));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.SOURCE_SYSTEM.选择通道(1));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.SOURCE_SYSTEM.设置电压值(_TestConfigs.PPT_V_CH1));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.SOURCE_SYSTEM.选择通道(2));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.SOURCE_SYSTEM.设置电压值(_TestConfigs.PPT_V_CH2));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.SOURCE_SYSTEM.选择通道(3));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.SOURCE_SYSTEM.设置电压值(_TestConfigs.PPT_V_CH3));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.OUTPUT_SYSTEM.输出开关("ON"));
            _PowerSupply_PSW.VisaWrite(_SCPI_PSW.OUTPUT_SYSTEM.输出开关(_TestConfigs.PSW_OUTPUT));

            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置功率(_TestConfigs.SignalSource_DBM));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.OUTPUT_SYSTEM.开or关输出("ON"));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.OUTPUT_SYSTEM.开or关调制MOD("ON"));

            _ControlModule.DriverPowerControl(ControlModule.驱动功放.开启);
        }

        public void OFF()
        {
            _ControlModule.DriverPowerControl(ControlModule.驱动功放.关闭);

            _SignalGener.VisaWrite(_SCPI_SignalGenerator.OUTPUT_SYSTEM.开or关输出("OFF"));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.OUTPUT_SYSTEM.开or关调制MOD("OFF"));

            _PowerSupply_PSW.VisaWrite(_SCPI_PSW.OUTPUT_SYSTEM.输出开关("OFF"));
            _PowerSupply_PPT.VisaWrite(_SCPI_PPT.OUTPUT_SYSTEM.输出开关("OFF"));           
        }

        public void 该测试前设置(脉宽类型 pulseWidth,decimal dutyRadio)
        {
            ON();
            
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置Pulse内外调制模式Mod("EXT"));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.OUTPUT_SYSTEM.开or关输出("ON"));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.OUTPUT_SYSTEM.开or关调制MOD("ON"));
            _SignalGener.VisaWrite(_SCPI_SignalGenerator.SOURCE_SYSTEM.设置功率("10dbm"));
            _PowerMeter.VisaWrite(_SCPI_PowerMeter.SYSTEM_SYSTEM.PRESET模式("RADar"));
            Thread.Sleep(2000);
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.OUTPUT_SYSTEM.开or关输出(1, "ON"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.OUTPUT_SYSTEM.开or关输出(2, "ON"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse上升沿时间设置(1, "4ns"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse下降沿时间设置(2, "4ns"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Voltage高电平设置(1, "5"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Voltage低电平设置(1, "0"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Voltage高电平设置(2, "5"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Voltage低电平设置(2, "0"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse延时设置(1, "0ns"));
            _WaveFormGenerator.VisaWrite(_SCPI_WaveForm.SOURCE_SYSTEM.Pulse延时设置(2, "500ns"));

            _ControlModule.DriverPowerControl(ControlModule.驱动功放.开启);
        }
    }
}
