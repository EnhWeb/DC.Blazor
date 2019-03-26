// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using DC.Storage;

namespace Microsoft.Extensions.DependencyInjection
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
        public static IServiceCollection AddDCStorage(this IServiceCollection services)
        {
            if (services.FirstOrDefault(d => d.ServiceType == typeof(ILocalStorageService)) == null)
            {
                services
                .AddScoped<ILocalStorageService, LocalStorageService>()  // 每次请求都会获取一个新的实例，但同一个请求内获取多次都只会得到相同的实例。
                .AddScoped<ISyncLocalStorageService, LocalStorageService>();

                services
                .AddScoped<ISessionStorageService, SessionStorageService>()
                .AddScoped<ISyncSessionStorageService, SessionStorageService>();
            }

            return services;
        }
    }
}
