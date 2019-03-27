using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace DC.Bue
{
    public class ComponentMapper : IComponentMapper
    {
        private readonly Dictionary<Type, Type> components = new Dictionary<Type, Type>();

        public Type GetImplementation<TComponent>()
            where TComponent : IComponent
        {
            return GetImplementation(typeof(TComponent));
        }

        public Type GetImplementation(IComponent component)
        {
            return GetImplementation(component.GetType());
        }

        public Type GetImplementation(Type componentType)
        {
            components.TryGetValue(componentType, out var implementationType);

            return implementationType;
        }

        public void Register<TComponent, TImplementation>()
            where TComponent : IComponent
            where TImplementation : IComponent
        {
            Register(typeof(TComponent), typeof(TImplementation));
        }

        public void Register(Type component, Type implementation)
        {
            if (!components.ContainsKey(component))
            {
                components.Add(component, implementation);
            }
        }

        public bool HasRegistration(IComponent component)
        {
            return HasRegistration(component.GetType());
        }

        private bool HasRegistration(Type type)
        {
            if (components.ContainsKey(type))
                return true;

            // 因为用户可以使用任何值数据类型和通用组件，我们必须动态注册这些组件实现
            if (type.IsGenericType)
            {
                var genericComponentType = type.GetGenericTypeDefinition();

                if (genericComponentType == null)
                    return false;

                // 获取没有值类型定义为泛型的泛型类型 例如. Button<> to BulmaButton<>
                if (components.TryGetValue(genericComponentType, out var genericImplementationType))
                {
                    // 获取泛型类型参数
                    var typeArguments = type.GenericTypeArguments;

                    // 基于泛型类型创建实际实现类型
                    var realComponentType = genericComponentType.MakeGenericType(typeArguments);
                    var realImplementationType = genericImplementationType.MakeGenericType(typeArguments);

                    // 保存新的实现
                    Register(realComponentType, realImplementationType);

                    return true;
                }
            }

            return false;
        }
    }
}
