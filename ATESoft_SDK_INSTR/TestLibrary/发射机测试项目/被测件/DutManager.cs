using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemOfSender.TestLibrary.发射机测试项目.被测件
{
    public class DutManager
    {
        public static Dut发射机 _Dut发射机 = new Dut发射机();
        public static Dut基础放大模块 _Dut基础放大模块 = new Dut基础放大模块();
        public static Dut驱动放大器 _Dut驱动放大器 = new Dut驱动放大器();

        public static List<Dut> _DutList  = new List<Dut>()
        {
            _Dut发射机,
            _Dut基础放大模块,
            _Dut驱动放大器
        };
        public static object FindDut(Dut dut,string key)
        {         
            return dut.DutConfigs.Where(m => m.ConfigName == key).FirstOrDefault().ConfigValue;
        }

        public static List<Dut> FindDut(string key,object value)
        {
            List<Dut> resDutList = new List<Dut>();
            foreach (var dut in _DutList)
            {
                if (dut.DutConfigs.Where(m=>m.ConfigName == key).FirstOrDefault().ConfigValue.ToString() == value.ToString())
                {
                    resDutList.Add(dut);
                }
            }
            return resDutList;
        }
        public static List<object> FindDut(string key)
        {
            List<object> resConfigValueList = new List<object>();        
            foreach (var dut in _DutList)
            {
                resConfigValueList.Add(dut.DutConfigs.Where(m => m.ConfigName == key).FirstOrDefault().ConfigValue);
            }
            return resConfigValueList;
        }
    }
}
