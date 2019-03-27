using DBlazor.HttpClientInterceptor;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDCStorage();  // 注册本地存储

            services.AddDCToast();  // 注册提示框

            services.AddDCLocalisation(); // 注册本地化

            services.AddDCHttpClientInterceptor(); // 注册Http请求拦截器

            services.AddDCLoadingBar();  // 注册顶部加载进度组件

            services.AddDCModal();  // 注册模态组件

            services.AddDCBue(options =>
            {
                options.ChangeTextOnKeyPress = true;
            })
            .AddDCEmptyProviders()
            .AddDCFontAwesomeIcons();  // 注册AwesomeIcons组件
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseDCLocalisationExtension();  // 启动本地化操作

            app.UseDCHttpClientInterceptor();  // 启用Http请求拦截器
            //var httpInterceptor = app.Services.GetService<HttpClientInterceptorService>();
            //httpInterceptor.BeforeSend += HttpInterceptor_BeforeSend;
            //httpInterceptor.AfterSend += HttpInterceptor_AfterSend;

            app.UseDCLoadingBar();  // 使用网页加载顶部导航组件

            app.UseDCFontAwesomeIcons();  //使用AwesomeIcons组件

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
