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
    public class 端口3测试
    {
        //矢网
        NetWorkAnalyzerBase _Net;
        PowerSupplyBase _Power;
        //矢网简单指令集
        NetWorkAnalyzerSCPIBase_CETC41 _NetSCPI = new NetWorkAnalyzerSCPIBase_CETC41();
        PowerSupplySCPIBase_GW_PSW _PowerSCPI = new PowerSupplySCPIBase_GW_PSW();

        public string _480MHz { get; set; }
        public string _20MHz { get;set;}
        public string _960MHz { get; set; }
        public string _120MHz { get;set;}
        public string _460MHz { get; set; }
        public string _500MHz { get; set; }

        public 端口3测试(NetWorkAnalyzerBase no,PowerSupplyBase power)
        {
            _Net = no;
            _Power = power;
        }

        public string Read480MHz输出功率()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }      
            _480MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 8));
            decimal res = Convert.ToDecimal(_480MHz) +10;
            return res.ToString("f2");
        }

        public string Read480MHz支路谐波抑制()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }

            _960MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 10));
            decimal res = Convert.ToDecimal(_480MHz) - Convert.ToDecimal(_960MHz);        
            res = Math.Abs(res) +15;
            return res.ToString("f2");
        }

        public string Read480MHz支路谐波抑制_20_120()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }
            string[] arr = new string[2];

            _20MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 1));
            _120MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 4));

            decimal res = Convert.ToDecimal(_480MHz) - Convert.ToDecimal(_20MHz);
            decimal res1 = Convert.ToDecimal(_480MHz) - Convert.ToDecimal(_120MHz);
            if (res>res1)
            {
                return res1.ToString("f2");
            }
            else
            {
                return res.ToString("f2");
            }
        }

        public string Read480MHz支路谐波抑制_460_500()
        {
            if (测试准备.WINCurrent != 测试准备.WIN2)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN2));
                测试准备.WINCurrent = 测试准备.WIN2;
            }

            string[] arr = new string[2];

            _460MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 7));
            _500MHz = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 9));

            decimal res1 = Convert.ToDecimal(_480MHz) - Convert.ToDecimal(_460MHz);
            decimal res = Convert.ToDecimal(_480MHz) - Convert.ToDecimal(_500MHz);

            if (res1>res)
            {
                return res.ToString("f2");
            }
            else
            {
                return res1.ToString("f2");
            }
        }


        public string Read480MHz的相位()
        {
            if (测试准备.WINCurrent != 测试准备.WIN3)
            {
                _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, 测试准备.WIN3));
                测试准备.WINCurrent = 测试准备.WIN3;
            }
            string res = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 8));
            res = Math.Abs(Convert.ToDecimal(res)).ToString("f2");
            return res;
        }

        public string Read电流()
        {
            string temp = "20";
            try
            {
                _Power.VisaOpen();
                temp = _Power.VisaRead(_PowerSCPI.MEASURE_SYSTEM.读取电流值());
                _Power.VisaClose();
            }
            catch (Exception)
            {
                //_Power.VisaClose();
            }

            return temp;
        }
    }
}
