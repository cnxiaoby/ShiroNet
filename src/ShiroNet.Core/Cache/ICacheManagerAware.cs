using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Cache
{
    public interface ICacheManagerAware
    {
        void SetCacheManager(ICacheManager cacheManager);
    }
}
