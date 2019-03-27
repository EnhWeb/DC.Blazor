// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using DC.Toast.Services;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用提示框的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册提示框服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddDCToast(this IServiceCollection services)
        {
            if (services.FirstOrDefault(d => d.ServiceType == typeof(IToastService)) == null)
            {
                services.AddScoped<IToastService, ToastService>();
            }

            return services;
        }
    }
}
