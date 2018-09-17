using ShiroNet.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Cache
{
    public abstract class AbstractCacheManager : ICacheManager, IDisposable
    {
        private IDictionary<string, ICache> caches;
        public AbstractCacheManager()
        {
            this.caches = new Dictionary<string, ICache>();
        }

        public ICache GetCache(string name)
        {
            if (!StringUtils.HasText(name))
            {
                throw new ArgumentException("Cache name cannot be null or empty.");
            }

            ICache cache;
            if (caches.ContainsKey(name))
            {
                cache = caches[name];
            }
            else
            {
                cache = CreateCache(name);
                caches.Add(name, cache);
            }

            return cache;
        }

        protected abstract ICache CreateCache(string name);

        public void Dispose()
        {
            foreach (var cache in caches.Values)
            {
                LifecycleUtils.Dispose(cache);
            }
            caches.Clear();
        }

        public override string ToString()
        {
            var values = caches.Values;
            StringBuilder sb = new StringBuilder(GetType().FullName)
                    .Append(" with ")
                    .Append(caches.Count)
                    .Append(" cache(s)): [");

            int i = 0;
            foreach (var cache in values)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(cache.ToString());
                i++;
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
