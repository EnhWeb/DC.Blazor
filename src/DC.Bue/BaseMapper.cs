using System;
using System.Collections.Generic;

namespace DC.Bue
{
    public interface IBaseMapper : IDisposable
    {
        void Dirty();

        IBaseMapper Add(string value);

        IBaseMapper Add(Func<string> value);

        IBaseMapper If(string value, Func<bool> condition);

        IBaseMapper If(Func<string> value, Func<bool> condition);

        IBaseMapper If(Func<IEnumerable<string>> values, Func<bool> condition);
    }

    public abstract class BaseMapper : IBaseMapper
    {
        /// <summary>
        /// 是否已释放
        /// </summary>
        private bool disposed;

        protected bool dirty = true;

        protected Dictionary<Func<string>, Func<bool>> rules;

        protected Dictionary<Func<IEnumerable<string>>, Func<bool>> listRules;

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        ~BaseMapper()
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
                if (!rule.Value())  // 跳过false的条件
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

        /// <summary>
        /// 将构建器标记为脏以重建值。
        /// </summary>
        public void Dirty()
        {
            dirty = true;
        }

        /// <summary>
        /// 将硬编码值添加到集合中。
        /// </summary>
        /// <param name="value">硬编码的样式类名</param>
        /// <returns></returns>
        public IBaseMapper Add(string value)
        {
            if (rules == null)
            {
                rules = new Dictionary<Func<string>, Func<bool>> { { () => value, () => true } };
            }
            else
            {
                rules.Add(() => value, () => true);
            }

            return this;
        }

        /// <summary>
        /// 为集合添加一个样式类名委托。
        /// </summary>
        /// <param name="value">样式类名委托</param>
        /// <returns></returns>
        public IBaseMapper Add(Func<string> value)
        {
            if (rules == null)
            {
                rules = new Dictionary<Func<string>, Func<bool>> { { value, () => true } };
            }
            else
            {
                rules.Add(value, () => true);
            }

            return this;
        }

        /// <summary>
        /// 向集合添加值，但仅在满足条件时才添加。
        /// </summary>
        /// <param name="value">硬编码值</param>
        /// <param name="condition">条件委托</param>
        /// <returns></returns>
        public IBaseMapper If(string value, Func<bool> condition)
        {
            if (rules == null)
            {
                rules = new Dictionary<Func<string>, Func<bool>> { { () => value, condition } };
            }
            else
            {
                rules.Add(() => value, condition);
            }

            return this;
        }

        /// <summary>
        /// 将样式类名委托添加到集合中，但仅在满足条件时才添加。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IBaseMapper If(Func<string> value, Func<bool> condition)
        {
            if (rules == null)
            {
                rules = new Dictionary<Func<string>, Func<bool>> { { value, condition } };
            }
            else
            {
                rules.Add(value, condition);
            }

            return this;
        }

        /// <summary>
        /// 将值列表委托添加到集合中，但仅在满足条件时才添加。
        /// </summary>
        /// <param name="values">样式类名委托</param>
        /// <param name="condition">条件委托</param>
        /// <returns></returns>
        public IBaseMapper If(Func<IEnumerable<string>> values, Func<bool> condition)
        {
            if (listRules == null)
            {
                listRules = new Dictionary<Func<IEnumerable<string>>, Func<bool>> { { values, condition } };
            }
            else
            {
                listRules.Add(values, condition);
            }

            return this;
        }
    }
}
