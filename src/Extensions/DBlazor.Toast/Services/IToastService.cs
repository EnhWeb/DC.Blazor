// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace DBlazor.Toast.Services
{
    /// <summary>
    /// 提示框接口
    /// </summary>
    public interface IToastService
    {
        /// <summary>
        /// 显示委托方法
        /// </summary>
        event Action<ToastLevel, string, string> OnShow;

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="level">消息等级</param>
        /// <param name="message">消息内容</param>
        /// <param name="heading">头部信息</param>
        void ShowToast(ToastLevel level, string message, string heading = "");
    }
}
