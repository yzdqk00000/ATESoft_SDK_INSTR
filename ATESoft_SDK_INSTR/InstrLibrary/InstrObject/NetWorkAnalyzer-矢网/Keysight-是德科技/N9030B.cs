using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// 矢网对象
    /// </summary>
    public class N9030B : NetWorkAnalyzerBase
    {
        public N9030B(string address) :base(address)
        {
        }

        public override void VisaWrite(string command)
        {
            base.VisaWrite(command);
        }

        public override void VisaAllWrite(string[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                //增加10毫秒延迟
                Thread.Sleep(10);
                base._ViError = AgVisa32.viPrintf(base._Session, commands[i] + "\n");
                if (base._ViError != 0)
                    throw new Exception("仪表连接错误！");
            }          
        }
    }

    /// <summary>
    /// 矢网：N9030B指令集
    /// </summary>
    public class N9030B_SCPI: NetWorkAnalyzerSCPIBase_Keysight
    {
        //重写CALC系统
        public new N9030B_CALC_SYSTEM CALC_SYSTEM = new N9030B_CALC_SYSTEM();

        /// <summary>
        /// 扩展+重写CALC系统
        /// </summary>
        public class N9030B_CALC_SYSTEM : CALCulate_System
        {
            public override string 设置Mark的X值(string freq, int cnum = 1, int mknum = 1)
            {

                string result = freq+cnum+mknum;
                return result;
            }
        }

        public N9030B_SCPI()
        {     
        }
    }
}
