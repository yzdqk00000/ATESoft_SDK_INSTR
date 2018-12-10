using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二十路功分网络TR.TestLibrary
{
    public class TestBase
    {
        public string PATH { get; set;} = "D:\\30303350\\30303350.cst";
        public bool IsLoad { get; set;} = false;

        public string WIN1 { get; } = Function_Module.GetConfig("窗口1");
        public string WIN2 { get; } = Function_Module.GetConfig("窗口2");
        public string WIN3 { get; } = Function_Module.GetConfig("窗口3");
        public string WIN4 { get; } = Function_Module.GetConfig("窗口4");
    }
}
