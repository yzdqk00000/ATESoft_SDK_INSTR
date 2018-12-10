using InstrLibrary.InstrObect;
using InstrLibrary.InstrDriver;
namespace TestLibrary
{
    /// <summary>
    /// 简单指令测试流程用例
    /// </summary>
    public class 端口驻波测试
    { 
        private NetWorkAnalyzerBase _Net;
        //配置SCPI指令集
        private NetWorkAnalyzerSCPIBase_Keysight _NetSCPI = new NetWorkAnalyzerSCPIBase_Keysight();

        private SpectrumAnalyzerBase _Spe;
        //配置SCPI指令集
        private SpectrumAnalyzerSCPIBase_CETC41 _SpeSCPI = new SpectrumAnalyzerSCPIBase_CETC41();

        public 端口驻波测试(NetWorkAnalyzerBase net, SpectrumAnalyzerBase spe)
        {
            _Net = net;
            _Spe = spe;
        }

        /// <summary>
        /// 开始测试流程
        /// </summary>
        /// <returns></returns>
        public string Start()
        {
            _Net.VisaOpen();
            _Net.VisaWrite(_NetSCPI.SENS_SYSTEM.设置带宽SPAN());
            //可读性强的流程代码
            _Net.VisaWrite(_NetSCPI.IDN_);
            _Net.VisaWrite(_NetSCPI.RST);
            _Net.VisaWrite(_NetSCPI.MEMM_SYSTEM.载入Memory("tang.csa"));
            _Net.VisaWrite(_NetSCPI.CALC_SYSTEM.设置Mark的X值("50MHz",1,2));

            string res = _Net.VisaRead(_NetSCPI.CALC_SYSTEM.读取Mark的Y值(1,2));

            _Net.VisaClose();
            return res;
        }
    }
}
