using System;
using DBlazor.Providers;
using DBlazor;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用Blazor的基础UI框架
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册DBlazor基础框架服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configureOptions">配置选项</param>
        /// <returns></returns>
        public static IServiceCollection AddDCBue( this IServiceCollection services, Action<DCOptions> configureOptions = null )
        {
            var options = new DCOptions();

            configureOptions?.Invoke( options );

            services.AddSingleton( options );

            return services;
        }

        /// <summary>
        /// 注册空的提供者
        /// </summary>
        /// <remarks>
        /// 通常不应该使用此方法，除非用户想要使用没有任何提供程序（如Bootstrap或Bulma）的扩展方法。
        /// </remarks>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddDCEmptyProviders( this IServiceCollection services)
        {
            services.AddSingleton<IClassProvider, EmptyClassProvider>();
            services.AddSingleton<IStyleProvider, EmptyStyleProvider>();
            services.AddSingleton<IComponentMapper, ComponentMapper>();

            services.AddScoped<IJSRunner, EmptyJSRunner>();

            return services;
        }

        /// <summary>
        /// Registers a custom class provider.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="classProviderFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddDCClassProvider( this IServiceCollection services, Func<IStyleProvider> classProviderFactory )
        {
            services.AddSingleton( ( p ) => classProviderFactory() );

            return services;
        }

        /// <summary>
        /// Registers a custom style provider.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="styleProviderFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddDCStyleProvider( this IServiceCollection services, Func<IStyleProvider> styleProviderFactory )
        {
            services.AddSingleton( ( p ) => styleProviderFactory() );

            return services;
        }

        /// <summary>
        /// Registers a custom js runner.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="jsRunnerFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddDCJSRunner( this IServiceCollection services, Func<IJSRunner> jsRunnerFactory )
        {
            services.AddScoped( ( p ) => jsRunnerFactory() );

            return services;
        }

        /// <summary>
        /// Registers a custom icon provider.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="iconProviderFactory"></param>
        public static IServiceCollection AddDCIconProvider( this IServiceCollection services, Func<IIconProvider> iconProviderFactory )
        {
            services.AddSingleton( ( p ) => iconProviderFactory() );

            return services;
        }
    }
}
