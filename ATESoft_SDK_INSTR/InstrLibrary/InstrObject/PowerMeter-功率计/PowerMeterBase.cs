using InstrLibrary.InstrDriver;
using System;

namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 功率计-基类
    /// </summary>
    public class PowerMeterBase : InstrBase
    {
        public PowerMeterBase(string address) : base(address)
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
                AgVisa32.viRead(_Session, out res, 17);
                dtmp = double.Parse(res);

                return dtmp;
            }
            catch (Exception)
            {
                OnchildThreadException("error:" + _InstrNick + "：数据采集失败");
                return 0;
            }
        }
    }


}
