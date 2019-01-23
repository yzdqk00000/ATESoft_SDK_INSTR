using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InstrLibrary.InstrDriver;
using System.Windows.Forms;
using DevExpress.XtraBars.Alerter;

namespace TestSystemOfSender.TestLibrary
{
    /*
     * 模块名称：多线程仪表连接
     * 功能描述：使用多线程同时连接多个仪表，节省时间
     * 业务逻辑：调用驱动库的异常处理方法接收异常，在ExceptionProcess中处理异常
     * */
    public class Common多线程连接仪表
    {
        private List<Thread> ThreadList = new List<Thread>();
        private RichTextBox RichTextBox;
        public Common多线程连接仪表(InstrBase[] instrBases,RichTextBox rich)
        {
            RichTextBox= rich;
            for (int i = 0; i < instrBases.Length; i++)
            {
                ThreadList.Add(new Thread(instrBases[i].VisaOpen));
                instrBases[i].ChildThreadException += new ChildThreadExceptionHandler(ExceptionProcess);
            }
        }

        public void Start()       
        {
            for (int i = 0; i < ThreadList.Count; i++)
            {
                ThreadList[i].IsBackground = true;
                ThreadList[i].Start();
            }     
        }
        public void Abort()
        {
            for (int i = 0; i < ThreadList.Count; i++)
                ThreadList[i].Abort();     
        }

        public void ExceptionProcess(string msg)
        {
            /*异常处理代码*/
            if (RichTextBox.InvokeRequired)
            {
                RichTextBox.Invoke(new EventHandler(delegate {
                    RichTextBox.AppendText(msg + "仪表连接异常！请重新启动程序或检查仪表连接" + "\n");
                }));
            }
            else
            {
                RichTextBox.AppendText(msg + "仪表连接异常！请重新启动程序或检查仪表连接" + "\n");
            }
    
        }
    }
}
