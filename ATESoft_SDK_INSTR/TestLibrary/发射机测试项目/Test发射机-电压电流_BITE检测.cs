using InstrLibrary.InstrObect;
using InstrLibrary.InstrDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class DataOfPSW
    {
        public decimal V { get;set;} = 0m;
        public decimal A { get;set;} = 0m;
    }

    public class DataOfPPT
    {
        public List<ChannelOfPower> ChannelOfPowerList = new List<ChannelOfPower>()
        {
            new ChannelOfPower() { Channel = 1,V = 0, A = 0},
            new ChannelOfPower() { Channel = 2,V = 0, A = 0},
            new ChannelOfPower() { Channel = 3,V = 0, A = 0},
        };
        public class ChannelOfPower
        {
            public int Channel { get;set;} = 1;
            public decimal V { get; set; } = 0m;
            public decimal A { get; set; } = 0m;
        }
    }
    public class Test发射机_电压电流_BITE检测
    {
        private PowerSupplyBase _PowerSupply_PSW;
        private PowerSupplyBase _PowerSupply_PPT;
        private ControlModule _ControlModule;

        private PowerSupplySCPIBase_GW_PSW _SCPI_PSW = new PowerSupplySCPIBase_GW_PSW();
        private PowerSupplySCPIBase_GW_PPT _SCPI_PPT = new PowerSupplySCPIBase_GW_PPT();
        
        private static Thread _PSW_Thread;
        private static Thread _PPT_Thread;
        private static Thread _BITE_Thread;

        public DataOfPSW _DataOfPSW = new DataOfPSW();
        public DataOfPPT _DataOfPPT = new DataOfPPT();
        public ControlModule.BITE结果类型 _DataOfBITE = ControlModule.BITE结果类型.断开连接;

        public int SpanOfRead { get; set; } = 5000;

        private void PPT_Work()
        {
            while (true)
            {
                for (int channelIndex = 0; channelIndex < 3; channelIndex++)
                {
                    _PowerSupply_PPT.VisaWrite(_SCPI_PPT.SOURCE_SYSTEM.选择通道(channelIndex + 1));
                    _DataOfPPT.ChannelOfPowerList[channelIndex].V = Convert.ToDecimal(_PowerSupply_PPT.VisaRead_double(_SCPI_PPT.SOURCE_SYSTEM.读取电压值()));
                    _DataOfPPT.ChannelOfPowerList[channelIndex].A = Convert.ToDecimal(_PowerSupply_PPT.VisaRead_double(_SCPI_PPT.SOURCE_SYSTEM.读取电流值()));
                }
                Thread.Sleep(SpanOfRead);
            }
        }
        private void PSW_Work()
        {
            while (true)
            {
                _DataOfPSW.V = Convert.ToDecimal(_PowerSupply_PSW.VisaRead_double(_SCPI_PSW.MEASURE_SYSTEM.读取电压值()));
                _DataOfPSW.A = Convert.ToDecimal(_PowerSupply_PSW.VisaRead_double(_SCPI_PSW.MEASURE_SYSTEM.读取电流值()));
                Thread.Sleep(SpanOfRead);
            }
        }
        private void BITE_Work()
        {
            while (true)
            {
                _DataOfBITE = _ControlModule.BITEControl();
                Thread.Sleep(SpanOfRead);
            }                  
        }

        public Test发射机_电压电流_BITE检测(PowerSupplyBase psw, PowerSupplyBase ppt,ControlModule control)
        {
            _PowerSupply_PSW = psw;
            _PowerSupply_PPT = ppt;
            _ControlModule = control;

            _PPT_Thread = new Thread(PPT_Work);
            _PSW_Thread = new Thread(PSW_Work);
            _BITE_Thread = new Thread(BITE_Work);

            _PSW_Thread.IsBackground = true; 
            _PPT_Thread.IsBackground = true;
            _BITE_Thread.IsBackground = true;
        }
        
        public void Start()
        {
            _PPT_Thread.Start();
            _PSW_Thread.Start();
            _BITE_Thread.Start();
        }

        public void Abort()
        {
            _PPT_Thread.Abort();
            _PSW_Thread.Abort();
            _BITE_Thread.Start();
        }
    }
}
