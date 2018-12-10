using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二十路功分网络TR.TestLibrary
{
    public class 驻波_相位_插损:TestBase
    {
        //矢网
        NetWorkAnalyzerBase _Net;

        //矢网简单指令集
        NetWorkAnalyzerSCPIBase_CETC41 _NetSCPI = new NetWorkAnalyzerSCPIBase_CETC41();

        public 驻波_相位_插损(NetWorkAnalyzerBase no)
        {
            _Net = no;
        }

        public int Index { get;set;} = 7;

        /// <summary>
        /// 总口驻波
        /// </summary>
        /// <returns></returns>
        public double 总口驻波测试()
        {
            if (!IsLoad) {_Net.VisaWrite(_NetSCPI.MEMM_SYSTEM.载入Memory(PATH)) ; IsLoad = true; }
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, WIN1));
    
            List<double> list = new List<double>();

            for (int i = 1; i <= 4; i++)
            {
                list.Add(double.Parse(_Net.VisaRead_Abs_两位(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, i))));
            }
                      
            return list.Max();
        }

        /// <summary>
        /// 普通口驻波
        /// </summary>
        /// <returns></returns>
        public double 普通口驻波测试()
        {
            if (!IsLoad)
            { _Net.VisaWrite(_NetSCPI.MEMM_SYSTEM.载入Memory(PATH)); IsLoad = true; }

            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, WIN4));

            return double.Parse(_Net.VisaRead_Abs_两位(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, 4)));
        }

        public double[] 幅度测试()
        {
            if (!IsLoad){ _Net.VisaWrite(_NetSCPI.MEMM_SYSTEM.载入Memory(PATH)); IsLoad = true; }
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, WIN2));

            List<double> list = new List<double>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(double.Parse(_Net.VisaRead_Abs(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, i))));
            }

            return list.ToArray();
        }

        public double[] 相位测试()
        {
            if (!IsLoad){ _Net.VisaWrite(_NetSCPI.MEMM_SYSTEM.载入Memory(PATH));IsLoad = true; }

            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.选择测试窗口根据名称(1, WIN3));

            List<double> list = new List<double>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(double.Parse(_Net.VisaRead_取整(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1, i))));
            }

            return list.ToArray();
        }

    }
}
