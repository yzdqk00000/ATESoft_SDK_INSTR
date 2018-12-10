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
    public class 端口2测试
    {
        //矢网
        NetWorkAnalyzerBase _Net;

        //矢网简单指令集
        NetWorkAnalyzerSCPIBase_CETC41 _NetSCPI = new NetWorkAnalyzerSCPIBase_CETC41();

        public string _20MHz { get; set; }
        public string _120MHz { get;set;}
        public string _240MHz { get; set; }
        public string _100MHz { get; set; }
        public string _140MHz { get; set; }

        public 端口2测试(NetWorkAnalyzerBase no)
        {
            _Net = no;

        }

        public string Read120MHz输出功率()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }      
            _120MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 4));
            decimal res = Convert.ToDecimal(_120MHz) +10;
            return res.ToString("f2");
        }

        public string Read120MHz支路谐波抑制()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }

            _240MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 6));
            decimal res = Convert.ToDecimal(_120MHz) - Convert.ToDecimal(_240MHz);   
            res = Math.Abs(res) -5;     
            return res.ToString("f2");
        }

        public string Read120MHz支路谐波抑制_20()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }
            _20MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 1));
            decimal res = Convert.ToDecimal(_120MHz) - Convert.ToDecimal(_20MHz);
            return res.ToString("f2");
        }

        public string Read120MHz支路谐波抑制_100_140()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }

            string[] arr = new string[2];

            _100MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 3));
            _140MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 5));

            decimal res1 = Convert.ToDecimal(_120MHz) - Convert.ToDecimal(_100MHz);
            decimal res = Convert.ToDecimal(_120MHz) - Convert.ToDecimal(_140MHz);

            arr[0] = res1.ToString("f2");
            arr[1] = res.ToString("f2");
            if (res>res1)
            {
                return res1.ToString("f2");
            }
            else
            {
                return res.ToString("f2");
            }
        }


        public string Read120MHz的相位()
        {
            if (测试准备.WINCurrent != 测试准备.WIN3)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN3));
                测试准备.WINCurrent = 测试准备.WIN3;
            }
            string res = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 4));
            res = Math.Abs(Convert.ToDecimal(res)).ToString("f2");
            return res;
        }

        public string Read各支路隔离度指标()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }
            string res = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 8));
            decimal res2 = Convert.ToDecimal(_120MHz) - Convert.ToDecimal(res);
            return res2.ToString("f2");
        }
    }
}
