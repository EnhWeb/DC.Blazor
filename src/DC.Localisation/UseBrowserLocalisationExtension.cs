using DC.Localisation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Globalization;

namespace Microsoft.AspNetCore.Components.Builder
{
    public static class UseBrowserLocalisationExtension
    {
        /// <summary>
        /// 注册前端本地化服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddDCLocalisation(this IServiceCollection services)
        {
            return services
                .AddScoped<ILocalisationService, LocalisationService>();
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
