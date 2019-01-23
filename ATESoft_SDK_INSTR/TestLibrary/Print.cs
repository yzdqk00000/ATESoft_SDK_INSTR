using InstrLibrary.InstrObect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class Print
    {
        N9030B_SCPI _SCPI = new N9030B_SCPI();
        NetWorkAnalyzerSCPI_Keysight_Complex _SCPI_Complex = new NetWorkAnalyzerSCPI_Keysight_Complex();
        
        public void Start()
        {
            Console.WriteLine(_SCPI.CALC_SYSTEM.设置测试显示格式());
            foreach (var item in _SCPI_Complex.连续设置5个不同的Mark())
            {
                Console.WriteLine(item);
            }
        }
    }
}
