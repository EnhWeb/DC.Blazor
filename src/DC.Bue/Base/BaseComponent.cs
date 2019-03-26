using Microsoft.AspNetCore.Components;
using System;

namespace DC.Bue.Base
{
    public abstract class BaseComponent : ComponentBase, IDisposable
    {
        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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

        /// <summary>
        /// 获取Class映射器
        /// </summary>
        protected ClassMapper ClassMapper { get; private set; } = new ClassMapper();

        /// <summary>
        /// 获取样式映射器
        /// </summary>
        protected StyleMapper StyleMapper { get; private set; } = new StyleMapper();
    }
}
