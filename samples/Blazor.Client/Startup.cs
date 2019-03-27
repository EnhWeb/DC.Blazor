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
            services.AddDCStorage();  // ע�᱾�ش洢

            services.AddDCToast();  // ע����ʾ��

            services.AddDCLocalisation(); // ע�᱾�ػ�

            services.AddDCHttpClientInterceptor(); // ע��Http����������

            services.AddDCLoadingBar();  // ע�ᶥ�����ؽ������

            services.AddDCModal();  // ע��ģ̬���

            services.AddDCBue(options =>
            {
                options.ChangeTextOnKeyPress = true;
            })
            .AddDCEmptyProviders()
            .AddDCFontAwesomeIcons();  // ע��AwesomeIcons���
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseDCLocalisationExtension();  // �������ػ�����

            app.UseDCHttpClientInterceptor();  // ����Http����������
            //var httpInterceptor = app.Services.GetService<HttpClientInterceptorService>();
            //httpInterceptor.BeforeSend += HttpInterceptor_BeforeSend;
            //httpInterceptor.AfterSend += HttpInterceptor_AfterSend;

            app.UseDCLoadingBar();  // ʹ����ҳ���ض����������

            app.UseDCFontAwesomeIcons();  //ʹ��AwesomeIcons���

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
