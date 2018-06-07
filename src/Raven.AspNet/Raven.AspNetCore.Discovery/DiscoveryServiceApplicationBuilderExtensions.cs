using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Raven.AspNetCore.Discovery.Consul
{
    /// <summary>
    /// 
    /// </summary>
    public static class DiscoveryServiceApplicationBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseConsulMonitor(this IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            IAutoServiceRegistration serviceEvent = (IAutoServiceRegistration)app.ApplicationServices.GetService(typeof(IAutoServiceRegistration));
            if (serviceEvent == null)
                throw new InvalidOperationException($"can not found: {typeof(IAutoServiceRegistration).FullName}");

            IHealthMiddlewareBuilder healthMiddlewareBuilder = (IHealthMiddlewareBuilder)app.ApplicationServices.GetService(typeof(IHealthMiddlewareBuilder));
            if (serviceEvent == null)
                throw new InvalidOperationException($"can not found: {typeof(IHealthMiddlewareBuilder).FullName}");

            lifetime.ApplicationStarted.Register(serviceEvent.OnStarted);//1:应用启动时加载配置,2:应用启动后注册服务中心
            lifetime.ApplicationStopping.Register(serviceEvent.OnStopping);//应用停止后从服务中心注销            
            
            return app.UseMiddleware(healthMiddlewareBuilder.HealthMiddlewareType);
            
        }
        //private static void OnStart()
        //{
        //    LoadAppConfig();
        //    RegService();
        //}
        //private static void LoadAppConfig()
        //{
        //    //加载应用配置
        //    Console.WriteLine("ApplicationStarted:LoadAppConfig");
        //}


        //private static void RegService()
        //{
        //    //先判断是否已经注册过了
        //    //this code is called when the application stops
        //    Console.WriteLine("ApplicationStarted:RegService");
        //}
        //private static void UnRegService()
        //{
        //    //this code is called when the application stops
        //    Console.WriteLine("ApplicationStopped:UnRegService");
        //}

    }
}
