// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Threading.Tasks;

namespace DC.Storage
{
    /// <summary>
    /// 异步存储接口
    /// </summary>
    public interface ISessionStorageService
    {
        /// <summary>
        /// 清空存储
        /// </summary>
        /// <returns></returns>
        Task Clear();

        /// <summary>
        /// 获取指定键值的存储内容
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">键值</param>
        /// <returns>对象</returns>
        Task<T> GetItem<T>(string key);

        /// <summary>
        /// 获取指定序列的Key名称
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns></returns>
        Task<string> Key(int index);

        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        Task<int> Length();

        /// <summary>
        /// 移除指定项
        /// </summary>
        /// <param name="key">键值</param>
        Task RemoveItem(string key);

        /// <summary>
        /// 存储
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="data">内容</param>
        /// <returns></returns>
        Task SetItem(string key, object data);

        /// <summary>
        /// 修改中
        /// </summary>
        event EventHandler<ChangingEventArgs> Changing;

        /// <summary>
        /// 修改完成
        /// </summary>
        event EventHandler<ChangedEventArgs> Changed;
    }
}
