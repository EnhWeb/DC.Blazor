namespace DCBlazor.Storage
{
    /// <summary>
    /// 修改中事件
    /// </summary>
    public class ChangingEventArgs : ChangedEventArgs
    {
        /// <summary>
        /// 是否取消
        /// </summary>
        public bool Cancel { get; set; }
    }
}
