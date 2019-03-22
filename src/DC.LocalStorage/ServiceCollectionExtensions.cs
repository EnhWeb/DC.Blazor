// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using DC.LocalStorage;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 服务注册扩展类
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册前端本地存储服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDCLocalStorage(this IServiceCollection services)
        {
            return services
                .AddScoped<ILocalStorageService, LocalStorageService>()  // 每次请求都会获取一个新的实例，但同一个请求内获取多次都只会得到相同的实例。
                .AddScoped<ISyncLocalStorageService, LocalStorageService>();
        }
    }
}
