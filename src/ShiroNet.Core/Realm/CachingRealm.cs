using ShiroNet.Authc;
using ShiroNet.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Realm
{
    public abstract class CachingRealm: IRealm, INameable, ICacheManagerAware, ILogoutAware
    {
    }
}
