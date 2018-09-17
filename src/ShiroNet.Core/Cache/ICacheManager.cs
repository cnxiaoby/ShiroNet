using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Cache
{
    public interface ICacheManager
    {
         ICache GetCache(string name);
    }
}
