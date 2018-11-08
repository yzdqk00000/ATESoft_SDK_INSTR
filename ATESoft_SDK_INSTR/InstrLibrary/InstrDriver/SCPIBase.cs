namespace InstrLibrary.InstrDriver
{
    /// <summary>
    /// SCPI-基类-基础指令
    /// </summary>
    public class SCPIBase
    {
        public string IDN_ = "*IDN?";
        public string CLS = "*CLS";
        public string ESE = "*ESE";
        public string ESE_ = "*ESE?";
        public string ESR_ = "*ESR?";
        public string OPC_ = "*OPC?";
        public string OPC = "*OPC";
        public string RST = "*RST";
        public string SRE = "*SRE";
        public string SRE_ = "*SRE";
        public string STB_ = "*STB?";
        public string TST_ = "*TST";
        public string WAI = "*WAI";
        public string TRG = "*TRG";
    }
}
