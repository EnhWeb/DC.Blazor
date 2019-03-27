using Microsoft.AspNetCore.Components;
using System;

namespace DC.Bue.Base
{
    public abstract class BaseComponent : ComponentBase, IDisposable
    {
        /// <summary>
        /// 释放非托管资源
        /// </summary>
        private bool disposed;

        private string customClass;

        private IClassProvider classProvider;

        /// <summary>
        /// 默认不浮动
        /// </summary>
        private Float @float = Float.None;

        /// <summary>
        /// 外间距
        /// </summary>
        private IFluentSpacing margin;

        /// <summary>
        /// 内间距
        /// </summary>
        private IFluentSpacing padding;

        private ParameterCollection parameters;

        public BaseComponent()
        {
            ElementId = Utils.IDGenerator.Instance.Generate;
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        ~BaseComponent()
        {
            Dispose(false);
        }

        /// <summary>
        /// 释放非托管和托管资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 根据条件判断是否释放托管资源
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (ClassMapper != null)
                    {
                        ClassMapper.Dispose();
                        ClassMapper = null;
                    }

                    if (StyleMapper != null)
                    {
                        StyleMapper.Dispose();
                        StyleMapper = null;
                    }
                }

                disposed = true;
            }
        }

        protected RenderFragment RenderCustomComponent()
        {
            return builder =>
            {
                builder.OpenComponent(0, ComponentMapper.GetImplementation(this));

                foreach (var parameter in parameters)
                {
                    builder.AddAttribute(1, parameter.Name, parameter.Value);
                }

                builder.CloseComponent();
            };
        }

        /// <summary>
        /// 获取Class映射器
        /// </summary>
        protected ClassMapper ClassMapper { get; private set; } = new ClassMapper();

        /// <summary>
        /// 获取样式映射器
        /// </summary>
        protected StyleMapper StyleMapper { get; private set; } = new StyleMapper();

        /// <summary>
        /// 获取或设置自定义组件映射器。
        /// </summary>
        [Inject] protected IComponentMapper ComponentMapper { get; set; }

        /// <summary>
        /// 获取元素的唯一ID。
        /// </summary>
        public string ElementId { get; }

        /// <summary>
        /// 注册样式类
        /// </summary>
        protected virtual void RegisterClasses()
        {
            ClassMapper
                .If(() => Class, () => Class != null)
                .If(() => Margin.Class(classProvider), () => Margin != null)
                .If(() => Padding.Class(classProvider), () => Padding != null)
                .If(() => ClassProvider.Float(Float), () => Float != Float.None);
        }

        [Inject] protected IClassProvider ClassProvider
        {
            get
            {
                return classProvider;
            }
            set
            {
                classProvider = value;

                RegisterClasses();
            }
        }

        /// <summary>
        /// Class元素的名称
        /// </summary>
        [Parameter] protected string Class
        {
            get
            {
                return customClass;
            }
            set
            {
                customClass = value;

                ClassMapper.Dirty();
            }
        }

        /// <summary>
        /// 浮动元素。
        /// </summary>
        [Parameter] protected Float Float
        {
            get
            {
                return @float;
            }
            set
            {
                @float = value;

                ClassMapper.Dirty();
            }
        }

        /// <summary>
        /// 定义元素边距。
        /// </summary>
        [Parameter] protected IFluentSpacing Margin
        {
            get
            {
                return margin;
            }
            set
            {
                margin = value;

                ClassMapper.Dirty();
            }
        }

        /// <summary>
        /// 定义元素填充间距。
        /// </summary>
        [Parameter] protected IFluentSpacing Padding
        {
            get
            {
                return padding;
            }
            set
            {
                padding = value;

                ClassMapper.Dirty();
            }
        }
    }
}
