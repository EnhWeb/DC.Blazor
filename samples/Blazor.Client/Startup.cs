using DC.HttpClientInterceptor;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDCLocalStorage();  // 注册本地存储

            services.AddDCToast();  // 注册提示框

            services.AddDCLocalisation(); // 注册本地化

            services.AddDCHttpClientInterceptor(); // 注册Http请求拦截器
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseDCLocalisationExtension();  // 启动本地化操作

            app.UseDCHttpClientInterceptor();  // 启用Http请求拦截器
            var httpInterceptor = app.Services.GetService<HttpClientInterceptorService>();
            httpInterceptor.BeforeSend += HttpInterceptor_BeforeSend;
            httpInterceptor.AfterSend += HttpInterceptor_AfterSend;

            app.AddComponent<App>("app");
        }

        private void HttpInterceptor_BeforeSend(object sender, EventArgs e)
        {
            Console.WriteLine("BeforeSend event of HttpClientInterceptor");
        }

        private void HttpInterceptor_AfterSend(object sender, EventArgs e)
        {
            Console.WriteLine("AfterSend event of HttpClientInterceptor");
        }
    }
}
