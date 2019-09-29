using DCBlazor.Storage.JsonConverters;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DCBlazor.Storage.LocalStorage
{
    /// <summary>
    /// 本地存储服务
    /// </summary>
    public class LocalStorageService : ILocalStorageService, ISyncLocalStorageService
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly IJSInProcessRuntime _jSInProcessRuntime;

        private JsonSerializerOptions _jsonOptions;

        public LocalStorageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            _jSInProcessRuntime = jSRuntime as IJSInProcessRuntime;
            _jsonOptions = new JsonSerializerOptions();
            _jsonOptions.Converters.Add(new TimespanJsonConverter());
        }

        /// <summary>
        /// 存储指定键名的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="data">值</param>
        /// <returns></returns>
        public async Task SetItemAsync(string key, object data)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            var e = await RaiseOnChangingAsync(key, data);

            if (e.Cancel)
            {
                return;
            }

            await _jSRuntime.InvokeAsync<object>("localStorage.setItem", key, JsonSerializer.Serialize(data, _jsonOptions));

            RaiseOnChanged(key, e.OldValue, data);
        }

        /// <summary>
        /// 获取指定键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetItemAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            var serialisedData = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (string.IsNullOrWhiteSpace(serialisedData))
                return default(T);

            return JsonSerializer.Deserialize<T>(serialisedData, _jsonOptions);
        }

        /// <summary>
        /// 移除指定键名
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task RemoveItemAsync(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            await _jSRuntime.InvokeAsync<object>("localStorage.removeItem", key);
        }

        /// <summary>
        /// 清空本地存储所有项
        /// </summary>
        /// <returns></returns>
        public async Task ClearAsync() => await _jSRuntime.InvokeAsync<object>("localStorage.clear");

        /// <summary>
        /// 获取存储的数据项数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> LengthAsync() => await _jSRuntime.InvokeAsync<int>("eval", "localStorage.length");

        /// <summary>
        /// 获取指定序号的键名
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<string> KeyAsync(int index) => await _jSRuntime.InvokeAsync<string>("localStorage.key", index);

        /// <summary>
        /// 检查键名是否在本地存储中，但不检查该值。
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>如果键名存在，则为true，否则为false</returns>
        public async Task<bool> ContainKeyAsync(string key) => await _jSRuntime.InvokeAsync<bool>("localStorage.hasOwnProperty", key);

        /// <summary>
        /// 存储指定键名的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void SetItem(string key, object data)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            var e = RaiseOnChangingSync(key, data);

            if (e.Cancel)
                return;

            _jSInProcessRuntime.Invoke<object>("localStorage.setItem", key, JsonSerializer.Serialize(data, _jsonOptions));

            RaiseOnChanged(key, e.OldValue, data);
        }

        /// <summary>
        /// 获取指定键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetItem<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            var serialisedData = _jSInProcessRuntime.Invoke<string>("localStorage.getItem", key);

            if (string.IsNullOrWhiteSpace(serialisedData))
                return default(T);

            return JsonSerializer.Deserialize<T>(serialisedData, _jsonOptions);
        }

        /// <summary>
        /// 移除指定键名
        /// </summary>
        /// <param name="key"></param>
        public void RemoveItem(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            _jSInProcessRuntime.Invoke<object>("localStorage.removeItem", key);
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            _jSInProcessRuntime.Invoke<object>("localStorage.clar");
        }

        /// <summary>
        /// 获取存储的数据项数量
        /// </summary>
        public int Length()
        {
            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            return _jSInProcessRuntime.Invoke<int>("eval", "localStorage.length");
        }

        /// <summary>
        /// 获取指定序号的键名
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Key(int index)
        {
            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            return _jSInProcessRuntime.Invoke<string>("localStorage.key", index);
        }

        /// <summary>
        /// 检查键名是否在本地存储中，但不检查该值。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainKey(string key)
        {
            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            return _jSInProcessRuntime.Invoke<bool>("localStorage.hasOwnProperty", key);
        }

        /// <summary>
        /// 异步修改中事件
        /// </summary>
        public event EventHandler<ChangingEventArgs> Changing;
        private async Task<ChangingEventArgs> RaiseOnChangingAsync(string key, object data)
        {
            var e = new ChangingEventArgs
            {
                Key = key,
                OldValue = await GetItemAsync<Object>(key),
                NewValue = data
            };

            Changing?.Invoke(this, e);

            return e;
        }

        /// <summary>
        /// 同步修改中事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private ChangingEventArgs RaiseOnChangingSync(string key, object data)
        {
            var e = new ChangingEventArgs
            {
                Key = key,
                OldValue = ((ISyncLocalStorageService)this).GetItem<object>(key),
                NewValue = data
            };

            Changing?.Invoke(this, e);

            return e;
        }

        /// <summary>
        /// 修改完成事件
        /// </summary>
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
