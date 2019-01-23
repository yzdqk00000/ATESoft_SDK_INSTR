using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrLibrary.InstrObect;

namespace TestSystemOfSender.TestLibrary.发射机测试项目
{
    public class TestProjectManager
    {
        public static Test发射机_输出峰值功率 _Test发射机_输出峰值功率 = new Test发射机_输出峰值功率(InstrManager._PowerMeterBase, InstrManager._SignalGenratorBase, InstrManager._ControlModule, InstrManager._WaveFormGeneratorBase);
        public static Test发射机_脉冲前后沿 _Test发射机_脉冲前后沿 = new Test发射机_脉冲前后沿(InstrManager._PowerMeterBase, InstrManager._SignalGenratorBase, InstrManager._ControlModule, InstrManager._WaveFormGeneratorBase);
        public static Test发射机_平顶降落 _Test发射机_平顶降落 = new Test发射机_平顶降落(InstrManager._PowerMeterBase, InstrManager._SignalGenratorBase, InstrManager._ControlModule, InstrManager._WaveFormGeneratorBase);
        public static Test发射机_脉内信杂比 _Test发射机_脉内信杂比 = new Test发射机_脉内信杂比(InstrManager._PowerMeterBase, InstrManager._SignalGenratorBase, InstrManager._SpectrumAnalyzerBase, InstrManager._ControlModule, InstrManager._WaveFormGeneratorBase);
        public static Test发射机_带内起伏 _Test发射机_带内起伏 = new Test发射机_带内起伏();
        public static Test发射机_功率控制 _Test发射机_功率控制 = new Test发射机_功率控制(InstrManager._PowerMeterBase, InstrManager._SignalGenratorBase, InstrManager._ControlModule, InstrManager._WaveFormGeneratorBase,InstrManager._SpectrumAnalyzerBase);
        public static Test测试前后开机与关机 _Test测试前后开机与关机 = new Test测试前后开机与关机(InstrManager._PowerMeterBase, InstrManager._SignalGenratorBase, InstrManager._ControlModule, InstrManager._WaveFormGeneratorBase, InstrManager._PowerSupply_PPT, InstrManager._PowerSupply_PSW);
        public static Test发射机_电压电流_BITE检测 _Test电压电流BITE检测 = new Test发射机_电压电流_BITE检测(InstrManager._PowerSupply_PSW,InstrManager._PowerSupply_PPT,InstrManager._ControlModule);
    }
}
