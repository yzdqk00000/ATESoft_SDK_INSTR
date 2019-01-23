using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrLibrary.InstrObect;
using InstrLibrary.InstrDriver;
using System.Windows.Forms;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class InstrManager
    {
        public static SignalGeneratorBase _SignalGenratorBase = new SignalGeneratorBase(Function_Module.GetConfig("信号源地址"));
        public static PowerMeterBase _PowerMeterBase = new PowerMeterBase(Function_Module.GetConfig("功率计地址"));
        public static ControlModule _ControlModule = new ControlModule();
        public static WaveformGeneratorBase _WaveFormGeneratorBase = new WaveformGeneratorBase(Function_Module.GetConfig("脉冲源地址"));
        public static SpectrumAnalyzerBase _SpectrumAnalyzerBase = new SpectrumAnalyzerBase(Function_Module.GetConfig("频谱仪地址"));
        public static PowerSupplyBase _PowerSupply_PSW = new PowerSupplyBase(Function_Module.GetConfig("PSW电源地址"));
        public static PowerSupplyBase _PowerSupply_PPT = new PowerSupplyBase(Function_Module.GetConfig("PPT电源地址"));

        public static void InitInstrNickName()
        {
            _SignalGenratorBase._InstrNick = "信号源";
            _PowerMeterBase._InstrNick = "功率计";
            _WaveFormGeneratorBase._InstrNick = "脉冲源";
            _SpectrumAnalyzerBase._InstrNick = "频谱仪";
            _PowerSupply_PPT._InstrNick = "PPT电源";
            _PowerSupply_PSW._InstrNick = "PSW电源";
        }

        public static void InitInstrConnect(RichTextBox richTextBox_消息提醒)
        {
            InstrBase[] InstrBases = new InstrBase[6]
            {
                 _SignalGenratorBase,
                 _PowerMeterBase,
                 _WaveFormGeneratorBase,
                 _SpectrumAnalyzerBase,
                 _PowerSupply_PPT,
                 _PowerSupply_PSW
            };
            if (richTextBox_消息提醒 != null)
            {
                if (richTextBox_消息提醒.InvokeRequired)
                {
                    richTextBox_消息提醒.Invoke(new EventHandler(delegate {
                        richTextBox_消息提醒.AppendText("控制模块状态反馈：" + _ControlModule.CheckListen().ToString());
                    }));
                }
                else
                {
                    richTextBox_消息提醒.AppendText("控制模块状态反馈：" + _ControlModule.CheckListen().ToString());
                }
            }

            Common多线程连接仪表 _ConnectInstr = new Common多线程连接仪表(InstrBases, richTextBox_消息提醒);
            _ConnectInstr.Start();

        }
    }
}
