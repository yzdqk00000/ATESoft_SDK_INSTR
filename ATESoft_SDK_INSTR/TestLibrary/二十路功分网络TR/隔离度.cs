using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 二十路功分网络TR.TestLibrary
{
    public class 隔离度 : TestBase
    {
        //矢网
        NetWorkAnalyzerBase _Net;

        //矢网简单指令集
        NetWorkAnalyzerSCPIBase_CETC41 _NetSCPI = new NetWorkAnalyzerSCPIBase_CETC41();

        public int Index { get; set; } = 7;

        public 隔离度(NetWorkAnalyzerBase no)
        {
            _Net = no;
        }

        public double Start()
        {
            if (!IsLoad) {_Net.VisaWrite(_NetSCPI.MEMM_SYSTEM.载入Memory(PATH)) ; IsLoad = true; }
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, WIN2));
            Thread.Sleep(1000);
            double res = Math.Round(double.Parse(_Net.VisaRead_Abs(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 5))));
            return res;
        }


    }
}
