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

        protected IEnumerable<string> GetValidRules()
        {
            foreach (var rule in rules)
            {
                if (!rule.Value())  // 跳过错误的条件
                {
                    continue;
                }

                var key = rule.Key();

                if (key != null)
                {
                    yield return key;
                }
            }
        }

        protected IEnumerable<string> GetValidListRules()
        {
            foreach (var listRule in listRules)
            {
                if (!listRule.Value())
                {
                    continue;
                }

                var key = listRule.Key();

                if(key == null)
                {
                    continue;
                }

                foreach (var value in key)
                {
                    yield return value;
                }
            }
        }
    }
}
