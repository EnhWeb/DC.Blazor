using DC.LoadingBar;
using Microsoft.AspNetCore.Components.Builder;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用LoadingBar的扩展方法
    /// </summary>
    public static class LoadingBarExtension
    {
        /// <summary>
        /// 注册网页加载顶部进度条服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddDCLoadingBar(this IServiceCollection services)
        {
            services.AddDCHttpClientInterceptor();

            if (services.FirstOrDefault(d => d.ServiceType == typeof(LoadingBarService)) == null)
            {
                services.AddSingleton<LoadingBarService>();
            }
        }

        private static bool Installed;

        /// <summary>
        /// 将网页加载顶部进度条服务安装到运行时宿主环境。
        /// </summary>
        /// <param name="app">运行时宿主环境</param>
        /// <returns></returns>
        public static IComponentsApplicationBuilder UseDCLoadingBar(this IComponentsApplicationBuilder app)
        {
            if (Installed) return app;

            app.UseDCHttpClientInterceptor();

            var loadingBar = app.Services.GetService<LoadingBarService>();
            loadingBar.ConstructDOM();

            Installed = true;
            return app;
        }

    }
}
