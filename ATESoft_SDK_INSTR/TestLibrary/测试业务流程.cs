using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrLibrary.InstrObect;
namespace TestLibrary
{
    /// <summary>
    /// 简单指令+复合指令一起使用测试流程用例
    /// </summary>
    public class 测试业务流程
    {
        //矢网
        NetWorkAnalyzerBase _Net;
        //矢网复合指令集
        NetWorkAnalyzerSCPI_Keysight_Complex _NetComplexSCPI = new NetWorkAnalyzerSCPI_Keysight_Complex();
        //矢网简单指令集
        NetWorkAnalyzerSCPIBase_Keysight _NetSCPI = new NetWorkAnalyzerSCPIBase_Keysight();


        public 测试业务流程(NetWorkAnalyzerBase no)
        {
            _Net = no;
        }

        public string[] Start()
        {
            _Net.VisaOpen();
            _Net.VisaAllWrite(_NetComplexSCPI.连续设置5个不同的Mark());
            List<string> res = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                res.Add(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, i));
            }      
            _Net.VisaClose();
            return res.ToArray();
        }
    }
}
