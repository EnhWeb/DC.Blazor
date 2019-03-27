using DBlazor.HttpClientInterceptor;
using Microsoft.AspNetCore.Components.Builder;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用HttpClientInterceptor的扩展方法。
    /// </summary>
    public static class HttpClientInterceptorExtension
    {
        /// <summary>
        /// 注册Http请求拦截服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddDCHttpClientInterceptor(this IServiceCollection services)
        {
            // 已经注册过则不再注册
            if (services.FirstOrDefault(d => d.ServiceType == typeof(HttpClientInterceptorService)) == null)
            {
                services.AddSingleton(_ => new HttpClientInterceptorService());
            }
        }

        /// <summary>
        /// 将Http请求拦截服务安装到运行时宿主环境。
        /// </summary>
        /// <param name="app">运行时宿主环境</param>
        /// <returns></returns>
        public static IComponentsApplicationBuilder UseDCHttpClientInterceptor(this IComponentsApplicationBuilder app)
        {
            var interceptor = app.Services.GetService<HttpClientInterceptorService>();
            interceptor.Install(app);

            return app;
        }

    }
}
