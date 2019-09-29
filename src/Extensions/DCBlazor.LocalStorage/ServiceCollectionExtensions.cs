using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCBlazor.Storage
{
    /// <summary>
    /// 添加和使用本地化存储的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册前端本地存储服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddDCBlazorStorage(this IServiceCollection services)
        {
            return services
                .AddScoped<ILocalStorageService, LocalStorageService>()
                .AddScoped<ISyncLocalStorageService, LocalStorageService>()
                .AddScoped<ISessionStorageService, SessionStorageService>()
                .AddScoped<ISyncSessionStorageService, SessionStorageService>();
        }
    }
}
