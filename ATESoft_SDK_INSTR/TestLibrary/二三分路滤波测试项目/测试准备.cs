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
    public class 测试准备
    {
        public static string WIN1 = "CH1_WIN1_LINE1_PARAM1";
        public static string WIN2 = "CH1_WIN2_LINE1_PARAM4"; 
        public static string WIN3 = "CH1_WIN3_LINE1_PARAM2";
        public static string WIN4 = "CH1_WIN4_LINE1_PARAM2"; 

        public static string WINCurrent = "";
        //矢网
        NetWorkAnalyzerBase _Net;

        //矢网简单指令集
        NetWorkAnalyzerSCPIBase_CETC41 _NetSCPI = new NetWorkAnalyzerSCPIBase_CETC41();


        public 测试准备(NetWorkAnalyzerBase no)
        {
            _Net = no;

        }

        public void Load()
        {
            _Net.VisaWrite(_NetSCPI.MEMM_SYSTEM.载入Memory("D:/123/123.cst"));
        }

        public void Init(string start,string stop)
        {
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, WIN1));
            for (int i = 1; i <= 10; i++)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.打开MARK点(1, i));
            }
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("20MHz", 1, 1));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("40MHz", 1, 2));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("100MHz", 1, 3));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("120MHz", 1, 4));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("140MHz", 1, 5));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("240MHz", 1, 6));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("460MHz", 1, 7));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("480MHz", 1, 8));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("500MHz", 1, 9));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("960MHz", 1, 10));


        }
    }
}
