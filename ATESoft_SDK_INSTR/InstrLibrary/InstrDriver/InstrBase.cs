using System;
using System.Threading;
using System.Threading.Tasks;

namespace InstrLibrary.InstrDriver
{
    /// <summary>
    /// 仪表-基类
    /// </summary>
    public delegate void ChildThreadExceptionHandler(string message);
    
    public class InstrBase
    {
        public event ChildThreadExceptionHandler ChildThreadException;
        public int _ResourceManager =0;
        public int _ViError = 0;
        public int _Session = 0;

        public string _InstrAddr { get; set; }
        public string _InstrNick { get;set;}="";
        public string InstrIDN { get;set;}
        
        public InstrBase(string address)
        {
            _InstrAddr = address;
        }
        protected virtual void OnchildThreadException(string message)
        {
            ChildThreadException?.Invoke(message);
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="command"></param>
        public virtual void PrintSCPI(string command)
        {
            Console.WriteLine(command);
        }
        /// <summary>
        /// 建立连接
        /// </summary>
        public virtual void VisaOpen()
        {
            _ViError = AgVisa32.viOpenDefaultRM(out _ResourceManager);
            if (_ViError != 0)
                OnchildThreadException("error:" +_InstrNick+ _InstrAddr);

            _ViError = AgVisa32.viOpen(_ResourceManager, _InstrAddr,
                    AgVisa32.VI_NO_LOCK, AgVisa32.VI_TMO_IMMEDIATE, out _Session);
            if (_ViError != 0)
                OnchildThreadException("error:" + _InstrNick + _InstrAddr);
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public virtual void VisaClose()
        {
            AgVisa32.viClose(_Session);
            AgVisa32.viClose(_ResourceManager);
        }

        /// <summary>
        /// 发送SCPI指令
        /// </summary>
        /// <param name="command"></param>
        public virtual void VisaWrite(string command)
        {
            _ViError = AgVisa32.viPrintf(_Session, command + "\n");
            if (_ViError != 0)
                OnchildThreadException("error:" + _InstrNick + _InstrAddr);   
        }

        /// <summary>
        /// 发送多条SCPI指令
        /// </summary>
        /// <param name="command"></param>
        public virtual void VisaAllWrite(string[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                _ViError = AgVisa32.viPrintf(_Session, commands[i] + "\n");
                if (_ViError != 0)
                    OnchildThreadException("error:" + _InstrNick + _InstrAddr);
            }
        }

        /// <summary>
        /// 返回字符串结果
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual string VisaRead(string command)
        {

            _ViError = AgVisa32.viPrintf(_Session, command + "\r\n");
            if (_ViError != 0)
                OnchildThreadException("error:" + _InstrNick + _InstrAddr);

            string res = "";
            Thread.Sleep(100);       
            try
            {
                AgVisa32.viRead(_Session, out res, 15);
                //string[] resa = res.Split(',');
                //res = resa[0];
                double dtmp = double.Parse(res);
                return dtmp.ToString("f2");
            }
            catch (Exception)
            {
                OnchildThreadException("error:" + _InstrNick + "：数据采集失败");
                return "0";
            }



        }

        /// <summary>
        /// 返回数值
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual double VisaRead_double(string command)
        {
            double dtmp;

            _ViError = AgVisa32.viPrintf(_Session, command + "\n");
            if (_ViError != 0)
                OnchildThreadException("error:" + _InstrNick + _InstrAddr);
            string res = "";     
            try
            {
                AgVisa32.viRead(_Session, out res, 15);
                //string[] resa = res.Split(',');
                //res = resa[0];
   
                dtmp = double.Parse(res);

                return dtmp;
            }
            catch (Exception)
            {
                OnchildThreadException("error:" + _InstrNick + "：数据采集失败");
                return 0;
            }

        }

        /// <summary>
        /// 返回数组
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual double[] VisaReads(string command)
        {
            double[] dtmp;

            _ViError = AgVisa32.viPrintf(_Session, command + "\n");
            if (_ViError != 0)
                OnchildThreadException("error:" + _InstrNick + _InstrAddr);

            string res = "";
            AgVisa32.viRead(_Session, out res, 8020);

            string[] tmp = res.Split(',');
            dtmp = new double[tmp.Length];

 
                for (int i = 0; i < tmp.Length; i++)
                {
                    dtmp[i] = double.Parse(tmp[i]);
                }


            return dtmp;
        }
    }
}
