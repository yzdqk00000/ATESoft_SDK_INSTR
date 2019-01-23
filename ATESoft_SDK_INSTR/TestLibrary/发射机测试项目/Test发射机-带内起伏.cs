using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class Test发射机_带内起伏
    {
        public const string TestName = "带内起伏";
        private double _Max = 0;     
        public double GetMax()
        {
            return 0;
        }
        private double _Min = 0;
        public double GetMin()
        {
            return 0;
        }

        public double GetDelta()
        {
            return 10*Math.Log10(_Max/_Min);
        }

        public double Get指标要求(频率工作范围 freq)
        {
            return 1;
        }
    }
}
