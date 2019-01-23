
using InstrLibrary.InstrDriver;
using System;

namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 频谱分析仪-基类
    /// </summary>
    public class SpectrumAnalyzerBase : InstrBase
    {
        public SpectrumAnalyzerBase(string address) : base(address)
        {           
            
        }

        public override double VisaRead_double(string command)
        {
            double dtmp;

            _ViError = AgVisa32.viPrintf(_Session, command + "\n");
            if (_ViError != 0)
                OnchildThreadException("error:" + _InstrNick + _InstrAddr);
            string res = "";    
            try
            {
                AgVisa32.viRead(_Session, out res, 15);
                dtmp = double.Parse(res);

                return dtmp;
            }
            catch (Exception)
            {
                OnchildThreadException("error:" + _InstrNick + "：数据采集失败");
                return 0;
            }
        }

        public override double[] VisaReads(string command)
        {
            double[] dtmp;

            _ViError = AgVisa32.viPrintf(_Session, command + "\n");
            if (_ViError != 0)
                OnchildThreadException("error:" + _InstrNick + _InstrAddr);

            string res = "";
            AgVisa32.viRead(_Session, out res, 100000);

            string[] tmp = res.Split(',');
            dtmp = new double[tmp.Length];

            try
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    dtmp[i] = double.Parse(tmp[i]);
                }
            }
            catch
            {
                Console.WriteLine();
            }

            return dtmp;
        }
    }


}
