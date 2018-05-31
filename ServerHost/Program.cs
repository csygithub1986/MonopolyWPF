using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.ServiceModel;
using MonopolyServer;
using System.Configuration;
using System.Reflection;
using System.ServiceModel.Configuration;

namespace MonopolyServerHost
{
    class Program
    {
        private static ProcessMutex SingleAppMutex = new ProcessMutex("{73d30a57-e0c2-4d57-9b69-af9e86ecce5f}");
        static void Main(string[] args)
        {
            if (!SingleAppMutex.IsCreator)
            {
                Console.WriteLine("已经有一个主机程序正在运行中！禁止重复启动！");
                System.Threading.Thread.Sleep(5000);//线程挂起5秒钟  
                Environment.Exit(1);//退出程序  
            }
            //Trace.Listeners.Clear();
            //Trace.Listeners.Add(new CachedTraceLinster() { UseLogFile = true, LogFileDirectory = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "Log"), DeleteExpiredLog = true, ExpireDays = 60 });
            //Trace.TraceInformation("程序开始启动");
            //Trace.TraceInformation("当前账户:" + Environment.UserName);

            if (string.Compare("SYSTEM", Environment.UserName, true) != 0)
            {
                Trace.TraceInformation("命令行方式运行程序");

                try
                {
                    bool re = ServerHost.Default.Start();
                    if (re)
                    {
                        Console.WriteLine("启动成功");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("启动失败");
                }

                Console.ReadKey();

                ServerHost.Default.Stop();

                return;
            }

            //Trace.TraceInformation("系统服务方式运行程序");
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new MainService()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
