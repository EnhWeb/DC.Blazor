// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace DC.Storage
{
    /// <summary>
    /// 本地存储服务
    /// </summary>
    public class SessionStorageService : ISessionStorageService, ISyncSessionStorageService
    {
        private readonly IJSRuntime _jSRuntime;  //表示可以调度调用的JavaScript运行时的实例。
        private readonly IJSInProcessRuntime _jsInProcessRuntime;  //表示可以调度调用的JavaScript运行时的实例。
        private string storageType = "sessionStorage";

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="jSRuntime"></param>
        public SessionStorageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            _jsInProcessRuntime = jSRuntime as IJSInProcessRuntime;
        }

        /// <summary>
        /// 异步存储
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="data">内容</param>
        /// <returns></returns>
        public async Task SetItem(string key, object data)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var e = await RaiseOnChangingAsync(key, data);

            if (e.Cancel)
                return;

            await _jSRuntime.InvokeAsync<object>("DC.Storage.SetItem", storageType, key, Json.Serialize(data));

            RaiseOnChanged(key, e.OldValue, data);
        }

        /// <summary>
        /// 异步获取指定键值的存储内容
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">键值</param>
        /// <returns>对象</returns>
        public async Task<T> GetItem<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var serialisedData = await _jSRuntime.InvokeAsync<string>("DC.Storage.GetItem", storageType, key);

            if (serialisedData == null)
                return default(T);

            return Json.Deserialize<T>(serialisedData);
        }

        /// <summary>
        /// 异步移除指定项
        /// </summary>
        /// <param name="key">键值</param>
        public Task RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            return _jSRuntime.InvokeAsync<object>("DC.Storage.RemoveItem", storageType, key);
        }

        /// <summary>
        /// 异步清空存储
        /// </summary>
        /// <returns></returns>
        public Task Clear() => _jSRuntime.InvokeAsync<object>("DC.Storage.Clear", storageType);

        /// <summary>
        /// 异步获取存储数量
        /// </summary>
        /// <returns></returns>
        public Task<int> Length() => _jSRuntime.InvokeAsync<int>("DC.Storage.Length", storageType);

        /// <summary>
        /// 获取指定序列的Key名称
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task<string> Key(int index) => _jSRuntime.InvokeAsync<string>("DC.Storage.Key", storageType, index);

        /// <summary>
        /// 同步存储
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="data">内容</param>
        void ISyncSessionStorageService.SetItem(string key, object data)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (_jsInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRunTime不可用");

            var e = RaiseOnChangingSync(key, data);

            if (e.Cancel)
                return;

            _jsInProcessRuntime.Invoke<object>("DC.Storage.SetItem", storageType, key, Json.Serialize(data));

            RaiseOnChanged(key, e.OldValue, data);
        }

        /// <summary>
        /// 同步获取指定键值的存储内容
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">键值</param>
        /// <returns>对象</returns>
        T ISyncSessionStorageService.GetItem<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (_jsInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRunTime不可用");

            var serialisedData = _jsInProcessRuntime.Invoke<string>("DC.Storage.GetItem", storageType, key);

            if (serialisedData == null)
                return default(T);

            return Json.Deserialize<T>(serialisedData);
        }

        /// <summary>
        /// 同步移除指定项
        /// </summary>
        /// <param name="key">键值</param>
        void ISyncSessionStorageService.RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (_jsInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRunTime不可用");

            _jsInProcessRuntime.Invoke<object>("DC.Storage.RemoveItem", storageType, key);
        }

        /// <summary>
        /// 同步清空存储
        /// </summary>
        void ISyncSessionStorageService.Clear()
        {
            if (_jsInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRunTime不可用");

            _jsInProcessRuntime.Invoke<object>("DC.Storage.Clear", storageType);
        }

        /// <summary>
        /// 同步获取存储数量
        /// </summary>
        /// <returns></returns>
        int ISyncSessionStorageService.Length()
        {
            if (_jsInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRunTime不可用");

            return _jsInProcessRuntime.Invoke<int>("DC.Storage.Length", storageType);
        }

        /// <summary>
        /// 获取指定序列的Key名称
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns></returns>
        string ISyncSessionStorageService.Key(int index)
        {
            if (_jsInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRunTime不可用");

            return _jsInProcessRuntime.Invoke<string>("DC.Storage.Key", storageType, index);
        }

        public event EventHandler<ChangingEventArgs> Changing;
        private async Task<ChangingEventArgs> RaiseOnChangingAsync(string key, object data)
        {
            var e = new ChangingEventArgs
            {
                Key = key,
                OldValue = await GetItem<object>(key),
                NewValue = data
            };

            Changing?.Invoke(this, e);

            return e;
        }

        private ChangingEventArgs RaiseOnChangingSync(string key, object data)
        {
            var e = new ChangingEventArgs
            {
                Key = key,
                OldValue = ((ISyncSessionStorageService)this).GetItem<object>(key),
                NewValue = data
            };

            Changing?.Invoke(this, e);
            return e;
        }

        public event EventHandler<ChangedEventArgs> Changed;
        private void RaiseOnChanged(string key, object oldValue, object data)
        {
            var e = new ChangedEventArgs
            {
                Key = key,
                OldValue = oldValue,
                NewValue = data
            };

            Changed?.Invoke(this, e);
        }
    }
}
