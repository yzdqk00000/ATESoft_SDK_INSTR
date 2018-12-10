using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 程控电源-基类
    /// </summary>
    public class PowerSupplyBase : InstrBase
    {
        public PowerSupplyBase(string address) : base(address)
        {           
            
        }

        public override string VisaRead(string command)
        {
            string res = "";
            _ViError = AgVisa32.viPrintf(_Session, command+ "\n");

            AgVisa32.viRead(_Session, out res, 1000);

            double dtmp = double.Parse(res) * 1000;
            return dtmp.ToString("f0");
        }
    }


}
