using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sample01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                   WebHost.CreateDefaultBuilder(args)//ʹ��Ĭ�ϵ�������Ϣ����ʼ��һ���µ�IWebHostBuilderʵ��
                   .ConfigureAppConfiguration((hostingContext, config) =>
                   {
                       var env = hostingContext.HostingEnvironment;
                       //����Content.json
                       config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                             .AddJsonFile("Content.json", optional: false, reloadOnChange: false)
                             .AddEnvironmentVariables();

                   })
                   .UseStartup<Startup>();// ΪWeb Hostָ����Startup��

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // ʹ��Ĭ�ϵ�������Ϣ����ʼ��һ���µ�IWebHostBuilderʵ��
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
