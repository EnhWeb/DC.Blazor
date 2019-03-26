using System;
using System.Collections.Generic;

namespace DC.Bue
{
    public interface IBaseMapper : IDisposable
    {

    }

    public abstract class BaseMapper : IBaseMapper
    {
        private bool disposed;

        protected bool dirty = true;

        protected Dictionary<Func<string>, Func<bool>> rules;

        protected Dictionary<Func<IEnumerable<string>>, Func<bool>> listRules;

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
                    if (rules != null)
                    {
                        rules.Clear();
                        rules = null;
                    }

                    if (listRules != null)
                    {
                        listRules.Clear();
                        listRules = null;
                    }
                }

                disposed = true;
            }
        }
    }
}
