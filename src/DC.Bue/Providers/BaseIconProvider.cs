using System.Collections.Generic;

namespace DC.Bue.Providers
{
    public abstract class BaseIconProvider : IIconProvider
    {
        /// <summary>
        /// 自定义图标字典
        /// </summary>
        private Dictionary<string, string> customIcons = new Dictionary<string, string>();

        /// <summary>
        /// 获取预定义的图标名称集合标识。
        /// </summary>
        /// <returns></returns>
        public abstract string Icon();

        /// <summary>
        /// 通过自定义图标名称获取图标名称
        /// </summary>
        /// <param name="customName"></param>
        /// <returns></returns>
        public string Get(string customName)
        {
            customIcons.TryGetValue(customName, out var name);

            return name;
        }

        /// <summary>
        /// 按预定义的图标类型获取图标名称。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract string Get(IconName name);

        /// <summary>
        /// 覆盖预定义的图标名称。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newName"></param>
        public abstract void Set(IconName name, string newName);

        /// <summary>
        /// 指示是否将类名定义为标记内容。
        /// </summary>
        public abstract bool IconNameAsContent { get; }
    }
}
