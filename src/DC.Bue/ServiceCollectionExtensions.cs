using DC.Bue;
using DC.Bue.Providers;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用DC.Bue基础框架的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册DC.Bue并配置默认行为。
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configureOptions">配置项</param>
        /// <returns></returns>
        public static IServiceCollection AddDCBue(this IServiceCollection services, Action<DCOptions> configureOptions = null)
        {
            var options = new DCOptions();
            configureOptions?.Invoke(options);
            services.AddSingleton(options);

            return services;
        }

        public static IServiceCollection AddDCEmptyProviders(this IServiceCollection services)
        {
            services.AddSingleton<IClassProvider, EmptyClassProvider>();
            services.AddSingleton<IStyleProvider, EmptyStyleProvider>();
            services.AddSingleton<IComponentMapper, ComponentMapper>();

            services.AddScoped<IJSRunner, EmptyJSRunner>();

            return services;
        }
    }
}
