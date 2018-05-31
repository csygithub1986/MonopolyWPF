using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace MonopolyServer
{
    /// <summary>
    /// 服务入口点
    /// </summary>
    public sealed class ServerHost
    {
        #region 单例
        public static ServerHost Default { get; private set; } = new Lazy<ServerHost>(() => new ServerHost(), true).Value;
        #endregion
        #region 定义        
        /// <summary>
        /// 服务器是否已启动
        /// </summary>
        public bool IsRunning { get; private set; }

        private ServiceHost m_ServiceHost { get; set; }
        #endregion

        #region 方法        
        /// <summary>
        /// 启动服务-服务器入口
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                Trace.TraceInformation("开始启动服务。");
                //if (!Logic.Default.InitSys())
                //{
                //    Trace.TraceError("服务启动失败,初始化数据失败。");
                //    return false;
                //}
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
                ServiceModelSectionGroup svcmod = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");
                if (svcmod != null)
                {
                    if (svcmod.Services.Services.Count == 0)
                    {
                        Trace.TraceError("系统服务未找到。");
                        return false;
                    }
                    foreach (ServiceElement item in svcmod.Services.Services)
                    {
                        Type svcType = Type.GetType(item.Name);
                        if (svcType == null)
                        {
                            Trace.TraceError("系统承载的服务类型为空。");
                            return false;
                        }
                        else
                        {
                            m_ServiceHost = new ServiceHost(svcType);
                            m_ServiceHost.Open();
                            //ServiceHosts.Add(serviceHost);
                        }
                    }
                    IsRunning = true;
                    Trace.TraceInformation("服务启动成功。");
                    return true;
                }
                else
                {
                    Trace.TraceError("未找到系统服务配置。");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止服务-服务器退出释放资源
        /// </summary>
        public void Stop()
        {
            try
            {
                Trace.TraceInformation("开始停止服务。");
                IsRunning = false;
                if (m_ServiceHost != null && m_ServiceHost.State != CommunicationState.Closed)
                {
                    try
                    {
                        m_ServiceHost.Close();
                    }
                    catch
                    {
                        m_ServiceHost.Abort();
                    }
                }
                //Logic.Default.CloseSys();
                Trace.TraceInformation("停止服务成功。");
            }
            catch (Exception ex) { System.Diagnostics.Trace.TraceError(ex.ToString()); }
        }
        #endregion
    }
}
