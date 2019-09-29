using System;

namespace DCBlazor.Storage
{
    /// <summary>
    /// 同步Session存储接口
    /// </summary>
    public interface ISyncSessionStorageService
    {
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
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
        /// 设置指定键名的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
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
