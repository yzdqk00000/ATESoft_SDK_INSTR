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
    public class 端口1测试
    {
        //矢网
        NetWorkAnalyzerBase _Net;

        //矢网简单指令集
        NetWorkAnalyzerSCPIBase_CETC41 _NetSCPI = new NetWorkAnalyzerSCPIBase_CETC41();

        public string _20MHz { get;set;}
        public string _40MHz { get; set; }
        public string _120MHz { get;set;}
        public string _480MHz { get; set; }

        public 端口1测试(NetWorkAnalyzerBase no)
        {
            _Net = no;

        }

        public string Read20MHz输出功率()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }      
            _20MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 1));
            decimal res = Convert.ToDecimal(_20MHz) +10;
            return res.ToString("f2");
        }

        public string Read20MHz支路谐波抑制()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }
            _40MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 2));
            decimal res = Convert.ToDecimal(_20MHz) - Convert.ToDecimal(_40MHz);
            res = Math.Abs(res) -15;     
            return res.ToString("f2");
        }

        public string Read20MHz支路谐波抑制_120_480()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }

            string[] arr = new string[2];
            _120MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 4));
            _480MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 8));

            decimal res1 = Convert.ToDecimal(_20MHz) - Convert.ToDecimal(_120MHz);
            decimal res = Convert.ToDecimal(_20MHz) - Convert.ToDecimal(_480MHz);

            if (res1>res)
            {
                return res.ToString("f2");
            }
            else
            {
                return res1.ToString("f2");
            }
        }

        public string Read20MHz的相位()
        {
            if (测试准备.WINCurrent != 测试准备.WIN3)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN3));
                测试准备.WINCurrent = 测试准备.WIN3;
            }
            string res = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 1));
            res = Math.Abs(Convert.ToDecimal(res)).ToString("f2");
            return res;
        }
    }
}
