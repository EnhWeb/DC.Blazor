// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace DC.LocalStorage
{
    public class ChangedEventArgs
    {
        /// <summary>
        /// 缓存键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 旧的缓存数据
        /// </summary>
        public object OldValue { get; set; }

        /// <summary>
        /// 新的缓存数据
        /// </summary>
        public object NewValue { get; set; }
    }
}
