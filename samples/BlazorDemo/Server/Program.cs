using Ding.Logs;
using Ding.Logs.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace BlazorDemo.Server
{
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        public static void Main(string[] args)
        {
            try
            {
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                ex.Log(Log.GetLog().Caption("应用程序启动失败"));
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            IConfigurationRoot configuration;

            if (args != null && args.Length > 0)
            {
                configuration = new ConfigurationBuilder()
                        .AddCommandLine(args)
                        .Build();
            }
            else
            {
                configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("hosting.json").Build();
            }

            return WebHost.CreateDefaultBuilder(args)
                    .UseConfiguration(configuration)
                    .ConfigureAppConfiguration((context, config) =>
                    {
                        // Configure the app here.

                    })
                    .UseStartup<Startup>()
                    .Build();
        }

    }
}
