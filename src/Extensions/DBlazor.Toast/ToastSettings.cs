// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace DBlazor.Toast
{
    /// <summary>
    /// 提示框设置
    /// </summary>
    public class ToastSettings
    {
        public ToastSettings(string heading, string message, string backgroudClass, string iconClass)
        {
            Heading = heading;
            Message = message;
            BackgroundClass = backgroudClass;
            IconClass = iconClass;
        }

        /// <summary>
        /// 背景样式
        /// </summary>
        public string BackgroundClass { get; set; }

        /// <summary>
        /// 头部标题
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// 图标样式
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; set; }
    }
}
