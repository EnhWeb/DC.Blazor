using System;
using System.Collections.Generic;
using System.Text;

namespace DCBlazor.Storage
{
    /// <summary>
    /// 修改完成事件
    /// </summary>
    public class ChangedEventArgs
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 旧的值
        /// </summary>
        public object OldValue { get; set; }

        /// <summary>
        /// 新的值
        /// </summary>
        public object NewValue { get; set; }
    }
}
