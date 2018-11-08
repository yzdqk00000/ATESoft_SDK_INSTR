using InstrLibrary.InstrDriver;
namespace InstrLibrary.InstrObect
{
    /// <summary>
    /// CETC41
    /// 
    /// 信号源-SCPI指令
    /// </summary>
    public class SignalGeneratorSCPIBase_CETC41 : SCPIBase
    {
        public CALCulate_System CALC_SYSTEM = new CALCulate_System();
        public MEMMory_System MEMM_SYSTEM = new MEMMory_System();

        /// <summary>
        /// CALC指令系统
        /// </summary>
        public class CALCulate_System
        {

        }

        /// <summary>
        /// MEMM指令系统
        /// </summary>
        public class MEMMory_System
        {
        }
    }

    
}
