using DCBlazor.Storage.JsonConverters;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DCBlazor.Storage
{
    /// <summary>
    /// Session存储服务
    /// </summary>
    public class SessionStorageService : ISessionStorageService, ISyncSessionStorageService
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly IJSInProcessRuntime _jSInProcessRuntime;

        private JsonSerializerOptions _jsonOptions;

        public SessionStorageService(IJSRuntime jSRuntime)
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
                return;

            await _jSRuntime.InvokeAsync<object>("sessionStorage.setItem", key, JsonSerializer.Serialize(data, _jsonOptions));

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

            var serialisedData = await _jSRuntime.InvokeAsync<string>("sessionStorage.getItem", key);

            if (serialisedData == null)
                return default(T);

            return JsonSerializer.Deserialize<T>(serialisedData);
        }

        /// <summary>
        /// 移除指定键名
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task RemoveItemAsync(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            await _jSRuntime.InvokeAsync<object>("sessionStorage.removeItem", key);
        }

        /// <summary>
        /// 清空本地存储所有项
        /// </summary>
        /// <returns></returns>
        public async Task ClearAsync() => await _jSRuntime.InvokeAsync<object>("sessionStorage.clear");

        /// <summary>
        /// 获取存储的数据项数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> LengthAsync() => await _jSRuntime.InvokeAsync<int>("eval", "sessionStorage.length");

        /// <summary>
        /// 获取指定序号的键名
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<string> KeyAsync(int index) => await _jSRuntime.InvokeAsync<string>("sessionStorage.key", index);

        /// <summary>
        /// 存储指定键名的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void SetItem(string key, object data)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            var e = RaiseOnChangingSync(key, data);

            if (e.Cancel)
                return;

            _jSInProcessRuntime.Invoke<object>("sessionStorage.setItem", key, JsonSerializer.Serialize(data));

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
                throw new ArgumentNullException(nameof(key));

            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            var serialisedData = _jSInProcessRuntime.Invoke<string>("sessionStorage.getItem", key);

            if (serialisedData == null)
                return default(T);

            return JsonSerializer.Deserialize<T>(serialisedData);
        }

        /// <summary>
        /// 移除指定键名
        /// </summary>
        /// <param name="key"></param>
        public void RemoveItem(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            _jSInProcessRuntime.Invoke<object>("sessionStorage.removeItem", key);
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            _jSInProcessRuntime.Invoke<object>("sessionStorage.clear");
        }

        /// <summary>
        /// 获取存储的数据项数量
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime无法使用");

            return _jSInProcessRuntime.Invoke<int>("eval", "sessionStorage.length");
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

            return _jSInProcessRuntime.Invoke<string>("sessionStorage.key", index);
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
                OldValue = await GetItemAsync<object>(key),
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
                OldValue = ((ISyncSessionStorageService)this).GetItem<object>(key),
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
