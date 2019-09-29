using System;
using System.Collections.Generic;
using System.Text;

namespace DCBlazor.Storage
{
    /// <summary>
    /// 同步本地存储接口
    /// </summary>
    public interface ISyncLocalStorageService
    {
        /// <summary>
        /// 清空
        /// </summary>
        void Clear();

        /// <summary>
        /// 获取指定键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetItem<T>(string key);

        /// <summary>
        /// 获取指定序号的键名
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string Key(int index);

        /// <summary>
        /// 检查键名是否在本地存储中，但不检查该值。
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>如果键名存在，则为true，否则为false</returns>
        bool ContainKey(string key);

        /// <summary>
        /// 获取存储的数据项数量
        /// </summary>
        /// <returns></returns>
        int Length();

        /// <summary>
        /// 移除指定键名
        /// </summary>
        /// <param name="key"></param>
        void RemoveItem(string key);

        /// <summary>
        /// 存储指定键名的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="data">值</param>
        void SetItem(string key, object data);

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
