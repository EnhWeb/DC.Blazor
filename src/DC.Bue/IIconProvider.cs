namespace DC.Bue
{
    public interface IIconProvider
    {
        /// <summary>
        /// 获取预定义的图标名称集合标识。
        /// </summary>
        /// <returns></returns>
        string Icon();

        /// <summary>
        /// 按预定义的图标类型获取图标名称。
        /// </summary>
        /// <param name="name">图标名称</param>
        /// <returns></returns>
        string Get(IconName name);

        /// <summary>
        /// 覆盖预定义的图标名称。
        /// </summary>
        /// <param name="name">图标名称</param>
        /// <param name="newName">对应的图标新名称</param>
        void Set(IconName name, string newName);

        /// <summary>
        /// 通过自定义图标名称获取图标名称。
        /// </summary>
        /// <param name="customName">自定义图标名称</param>
        /// <returns></returns>
        string Get(string customName);

        /// <summary>
        /// 指示是否将类名定义为标记内容。
        /// </summary>
        bool IconNameAsContent { get; }
    }
}
