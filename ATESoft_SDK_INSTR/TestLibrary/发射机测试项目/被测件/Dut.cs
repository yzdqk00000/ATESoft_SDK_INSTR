using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目.被测件
{
    public abstract class Dut
    {
        public abstract List<DutConfig> DutConfigs { get;set;}

        public virtual object GetDutConfig(string key)
        {
            return DutConfigs.Where(m => m.ConfigName == key).FirstOrDefault().ConfigValue;
        }

        public virtual void SetDutConfig(string key, object value)
        {
            DutConfigs.Where(m => m.ConfigName == key).FirstOrDefault().ConfigValue = value.ToString();
        }

        public abstract void ConfigTestProject();

        
    }

    public class DutConfig
    {
        public string ConfigName { get;set;}
        public object ConfigValue { get;set;}
    }
}
