using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目.被测件
{
    public class Dut基础放大模块 : Dut
    {
        private List<DutConfig> DutConfigList = new List<DutConfig>();

        public override List<DutConfig> DutConfigs
        {
            get { return DutConfigList; }
            set { DutConfigList = value; }
        }

        public Dut基础放大模块()
        {
            DutConfigList.Add(new DutConfig() { ConfigName = "被测件名称", ConfigValue = "基础放大模块" });
            DutConfigList.Add(new DutConfig() { ConfigName = "信号源输出功率", ConfigValue = "2.5" });
            DutConfigList.Add(new DutConfig() { ConfigName = "PSW电源电压", ConfigValue = "0" });
            DutConfigList.Add(new DutConfig() { ConfigName = "PSW电源输出状态", ConfigValue = "OFF" });
            DutConfigList.Add(new DutConfig() { ConfigName = "PPT-通道1-电源电压", ConfigValue = "6.5" });
            DutConfigList.Add(new DutConfig() { ConfigName = "PPT-通道2-电源电压", ConfigValue = "0" });
            DutConfigList.Add(new DutConfig() { ConfigName = "PPT-通道3-电源电压", ConfigValue = "-1.8" });
            DutConfigList.Add(new DutConfig() { ConfigName = "测试项目", ConfigValue = new List<string>
            {
                Test发射机_输出峰值功率.TestName,
            } });     
        }

        public override void ConfigTestProject()
        {
            TestProjectManager._Test测试前后开机与关机._TestConfigs.SignalSource_DBM = GetDutConfig("信号源输出功率").ToString();
            TestProjectManager._Test测试前后开机与关机._TestConfigs.PSW_V = GetDutConfig("PSW电源电压").ToString();
            TestProjectManager._Test测试前后开机与关机._TestConfigs.PPT_V_CH1 = GetDutConfig("PPT-通道1-电源电压").ToString();
            TestProjectManager._Test测试前后开机与关机._TestConfigs.PPT_V_CH2 = GetDutConfig("PPT-通道2-电源电压").ToString();
            TestProjectManager._Test测试前后开机与关机._TestConfigs.PPT_V_CH3 = GetDutConfig("PPT-通道3-电源电压").ToString();
            TestProjectManager._Test测试前后开机与关机._TestConfigs.PSW_OUTPUT = GetDutConfig("PSW电源输出状态").ToString();
        }
    }
}
