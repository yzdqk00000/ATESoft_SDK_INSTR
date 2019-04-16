using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestSystemOfSender
{
    public class ControlModule
    {
        public enum 驱动功放
        {
            开启 = 0x01,
            关闭 = 0x00,
        }
        public enum BITE结果类型
        {
            正常 = 0x03,
            电源故障 = 0x02,
            功率检测故障 = 0x01,
            电源功率均故障 = 0x00,
            断开连接 = 0x04,
        }
        public enum 仪表选择
        {
            频谱仪 = 0x01,
            功率计 = 0x00,
        }
        public enum 功率控制
        {
            _6_2dB = 0x02,
            _12_2dB = 0x00,
            _0dB = 0x03 
        }
        public static long _NumberForInterLock = 1;
        private string _RemoteIP { get; set; } = "10.100.18.200";
        private int _RemotePort { get; set; } = 8080;
        private int _LocalPort { get;set;} = 8080;
        private IPEndPoint _LocalEndPoint { get; set; }
        private UdpClient _UdpClient { get;set;}

        public ControlModule()
        {       
            _RemoteIP = Function_Module.GetConfig("控制模块IP");
            _RemotePort = Convert.ToInt32(Function_Module.GetConfig("控制模块端口"));
        }


        private void _CreateUdpClient(string localip,int localPort)
        {
            try
            {
                IPAddress localIP = IPAddress.Parse(localip);
                _LocalEndPoint = new IPEndPoint(localIP, localPort);
                _UdpClient = new UdpClient(_LocalEndPoint);
            }
            catch (Exception ex)
            {
                
            }   
        }
        /// <summary>
        /// 监听自检
        /// </summary>
        public BITE结果类型 CheckListen()
        {
            try
            {
                while (Interlocked.Read(ref _NumberForInterLock) == 0)
                {
                    Thread.Sleep(5);
                }
                Interlocked.Decrement(ref _NumberForInterLock);

                _CreateUdpClient(Function_Module.GetConfig("本机IP"),Convert.ToInt32(Function_Module.GetConfig("本机端口")));

                _UdpClient.Close();
                Interlocked.Increment(ref _NumberForInterLock);
                return BITE结果类型.正常;     
            }
            catch (Exception)
            {         
                if (_UdpClient != null)
                {
                    _UdpClient.Close();
                }
                Interlocked.Increment(ref _NumberForInterLock);
                return BITE结果类型.断开连接;
            }
        }


        public bool DriverPowerControl(驱动功放 power)
        {
            while (Interlocked.Read(ref _NumberForInterLock) == 0)
            {
                Thread.Sleep(5);
            }
            Interlocked.Decrement(ref _NumberForInterLock);

            _CreateUdpClient(Function_Module.GetConfig("本机IP"), Convert.ToInt32(Function_Module.GetConfig("本机端口")));
            byte[] sendBytes = GetDriverPowerControl(power);
            byte[] recvBytes = new byte[6];
            try
            {
                _UdpClient.Send(sendBytes, sendBytes.Length, _RemoteIP, _RemotePort);
                _UdpClient.Client.ReceiveTimeout = 3000;
                if (_UdpClient.Client.Receive(recvBytes)>0)
                {
                    _UdpClient.Close();
                    Interlocked.Increment(ref _NumberForInterLock);
                    return true;
                }
                else
                {
                    _UdpClient.Close();
                    Interlocked.Increment(ref _NumberForInterLock);
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (_UdpClient != null)
                {
                    _UdpClient.Close();
                }
                Console.WriteLine(ex.Message);
                Interlocked.Increment(ref _NumberForInterLock);
                return false;
            }

            
        }

        public byte[] GetDriverPowerControl(驱动功放 power)
        {
            byte[] sendBytes = new byte[6] { 0xff, 0xaa, 0x00, 0x00, 0x00, 0xdd };
          
            sendBytes[2] = (byte)power;
            return sendBytes;
        }

        public byte[] GetBITEControl()
        {
            byte[] sendBytes = new byte[6] { 0xff, 0xbb, 0x00, 0x00, 0x00, 0xdd };
            return sendBytes;
        }
        public BITE结果类型 BITEControl()
        {
            while (Interlocked.Read(ref _NumberForInterLock) == 0)
            {
                Thread.Sleep(5);
            }
            Interlocked.Decrement(ref _NumberForInterLock);

            _CreateUdpClient(Function_Module.GetConfig("本机IP"), Convert.ToInt32(Function_Module.GetConfig("本机端口")));

            byte[] sendBytes = GetBITEControl();
            byte[] recvBytes = new byte[6];
            try
            {
                _UdpClient.Send(sendBytes, sendBytes.Length, _RemoteIP, _RemotePort);
                _UdpClient.Client.ReceiveTimeout = 3000;
                if (_UdpClient.Client.Receive(recvBytes) > 0)
                {
                    _UdpClient.Close();
                    Interlocked.Increment(ref _NumberForInterLock);
                    return (BITE结果类型)recvBytes[2];
                }
                else
                {
                    _UdpClient.Close();
                    Interlocked.Increment(ref _NumberForInterLock);
                    return BITE结果类型.断开连接;
                }
            }
            catch (Exception)
            {
                if (_UdpClient != null)
                {
                    _UdpClient.Close();
                }
                Interlocked.Increment(ref _NumberForInterLock);
                return BITE结果类型.断开连接;
            }
        }

        public bool PowerControl(功率控制 power)
        {
            while (Interlocked.Read(ref _NumberForInterLock) == 0)
            {
                Thread.Sleep(5);
            }
            Interlocked.Decrement(ref _NumberForInterLock);

            _CreateUdpClient(Function_Module.GetConfig("本机IP"), Convert.ToInt32(Function_Module.GetConfig("本机端口")));
            byte[] sendBytes = GetPowerControl(power);
            byte[] recvBytes = new byte[6];
            try
            {
                _UdpClient.Send(sendBytes, sendBytes.Length, _RemoteIP, _RemotePort);
                _UdpClient.Client.ReceiveTimeout = 3000;
                if (_UdpClient.Client.Receive(recvBytes) > 0)
                {
                    _UdpClient.Close();
                    Interlocked.Increment(ref _NumberForInterLock);
                    return true;
                }
                else
                {
                    _UdpClient.Close();
                    Interlocked.Increment(ref _NumberForInterLock);
                    return false;
                }
            }
            catch (Exception)
            {
                if (_UdpClient != null)
                {
                    _UdpClient.Close();
                }
                Interlocked.Increment(ref _NumberForInterLock);
                return false;
            }
        }
        public byte[] GetPowerControl(功率控制 power)
        {
            byte[] sendBytes = new byte[6] { 0xff, 0xdd, 0x00, 0x00, 0x00, 0xdd };

            sendBytes[2] = (byte)power;
            return sendBytes;
        }

        public byte[] GetSwitchControl(仪表选择 control)
        {
            byte[] sendBytes = new byte[6] { 0xff, 0xcc, 0x00, 0x00, 0x00, 0xdd };
            sendBytes[2] = (byte)control;
            return sendBytes;
        }
        public void SwitchControl(仪表选择 control)
        {
            while (Interlocked.Read(ref _NumberForInterLock) == 0)
            {
                Thread.Sleep(5);
            }
            Interlocked.Decrement(ref _NumberForInterLock);

            _CreateUdpClient(Function_Module.GetConfig("本机IP"), Convert.ToInt32(Function_Module.GetConfig("本机端口")));
            byte[] sendBytes = GetSwitchControl(control);
            try
            {
                _UdpClient.Send(sendBytes, sendBytes.Length, _RemoteIP, _RemotePort);
                _UdpClient.Close();
                Interlocked.Increment(ref _NumberForInterLock);
            }
            catch (Exception)
            {
                if (_UdpClient != null)
                {
                    _UdpClient.Close();
                }
                Interlocked.Increment(ref _NumberForInterLock);
            }        
        }
    }
}
