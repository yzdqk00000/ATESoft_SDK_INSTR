using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace ATESoft_SDK_INSTR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //创建仪表
            N9030B n9030B = new N9030B("TCPIP::192.168.1.100::INSTR");
            NXXXX nxxx = new NXXXX("GPIB::15::INSTR");
            
            SpectrumAnalyzerBase spe = new SpectrumAnalyzerBase("TCPIP::192.168.1.101::INSTR");

            SignalGeneratorSCPIBase_Keysight keysight_scpi = new SignalGeneratorSCPIBase_Keysight();

            Console.WriteLine(keysight_scpi.SOURCE_SYSTEM.设置功率("50dbm"));
            Console.WriteLine(keysight_scpi.SOURCE_SYSTEM.设置频率("50MHz"));

            //测试业务流程
            //端口驻波测试 port = new 端口驻波测试(n9030B, spe);
            //port.Start();

            //测试业务流程 test = new 测试业务流程(nxxx);
            //port.Start();


            //指令演示
            //N9030B_SCPI scpi = new N9030B_SCPI();
            //Console.WriteLine(scpi.CALC_SYSTEM.设置Mark的X值("50MHz"));
            //Console.WriteLine(scpi.CALC_SYSTEM.读取Mark的Y值());
        }
    }
}
