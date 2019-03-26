using Microsoft.AspNetCore.Components;
using System;

namespace DC.Bue
{
    /// <summary>
    /// 所有自定义组件实现的映射。
    /// </summary>
    public interface IComponentMapper
    {
        /// <summary>
        /// 将实现组件类型注册到基本组件。
        /// </summary>
        /// <param name="component">基本组件类型。</param>
        /// <param name="implementation">实现组件类型。</param>
        void Register(Type component, Type implementation);

        /// <summary>
        /// 检查组件是否具有自定义实现。
        /// </summary>
        /// <param name="component">要检查的组件。</param>
        /// <returns>如果注册存在，则返回true。</returns>
        bool HasRegistration(IComponent component);
    }
}
