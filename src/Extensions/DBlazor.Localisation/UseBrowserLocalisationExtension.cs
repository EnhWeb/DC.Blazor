using DC.Localisation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Globalization;
using System.Linq;

namespace Microsoft.AspNetCore.Components.Builder
{
    /// <summary>
    /// 添加和使用本地化的扩展方法
    /// </summary>
    public static class UseBrowserLocalisationExtension
    {
        /// <summary>
        /// 注册前端本地化服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddDCLocalisation(this IServiceCollection services)
        {
            if (services.FirstOrDefault(d => d.ServiceType == typeof(ILocalisationService)) == null)
            {
                services
                .AddScoped<ILocalisationService, LocalisationService>();
            }

            return services;
        }

        /// <summary>
        /// 将本地化服务安装到运行时宿主环境。
        /// </summary>
        /// <param name="app">宿主环境</param>
        public static void UseDCLocalisationExtension(this IComponentsApplicationBuilder app)
        {
            var jsRuntime = app.Services.GetService(typeof(IJSRuntime));
            var browserLocale = ((IJSInProcessRuntime)jsRuntime).Invoke<string>("DC.Localisation.GetBrowserLocale");
            var culture = new CultureInfo(browserLocale);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
