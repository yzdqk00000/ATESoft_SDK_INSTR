namespace InstrLibrary.InstrDriver
{
    /// <summary>
    /// SCPI-基类-基础指令
    /// </summary>
    public class SCPIBase
    {
        public static class COMMON
        {
            public static string IDN_ = "*IDN?";
            public static string CLS = "*CLS";
            public static string ESE = "*ESE";
            public static string ESE_ = "*ESE?";
            public static string ESR_ = "*ESR?";
            public static string OPC_ = "*OPC?";
            public static string OPC = "*OPC";
            public static string RST = "*RST";
            public static string SRE = "*SRE";
            public static string SRE_ = "*SRE";
            public static string STB_ = "*STB?";
            public static string TST_ = "*TST";
            public static string WAI = "*WAI";
            public static string TRG = "*TRG";
        }
    }
}
