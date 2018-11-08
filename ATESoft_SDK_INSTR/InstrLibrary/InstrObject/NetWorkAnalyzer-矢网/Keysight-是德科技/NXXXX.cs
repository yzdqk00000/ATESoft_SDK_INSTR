using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrLibrary.InstrObect
{
    public class NXXXX : NetWorkAnalyzerBase
    {
        public NXXXX(string address) : base(address)
        {
        }
    }

    public class NXXX_SCPI:NetWorkAnalyzerSCPIBase_CETC41
    {

    }
}
