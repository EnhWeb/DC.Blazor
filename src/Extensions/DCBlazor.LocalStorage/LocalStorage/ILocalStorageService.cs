using System;
using System.Threading.Tasks;

namespace DCBlazor.Storage
{
    /// <summary>
    /// 异步本地存储接口
    /// </summary>
    public interface ILocalStorageService
    {
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        Task ClearAsync();

        /// <summary>
        /// 获取指定键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetItemAsync<T>(string key);

        /// <summary>
        /// 获取指定序号的键名
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<string> KeyAsync(int index);

        /// <summary>
        /// 检查键名是否在本地存储中，但不检查该值。
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>如果键名存在，则为true，否则为false</returns>
        Task<bool> ContainKeyAsync(string key);

        /// <summary>
        /// 获取存储的数据项数量
        /// </summary>
        /// <returns></returns>
        Task<int> LengthAsync();

        /// <summary>
        /// 移除指定键名
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveItemAsync(string key);

        /// <summary>
        /// 设置指定键名的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task SetItemAsync(string key, object data);

        /// <summary>
        /// 修改中事件
        /// </summary>
        event EventHandler<ChangingEventArgs> Changing;

        /// <summary>
        /// 修改完成事件
        /// </summary>
        event EventHandler<ChangedEventArgs> Changed;
    }
}
