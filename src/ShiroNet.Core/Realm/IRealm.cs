using ShiroNet.Authc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Realm
{
    public interface IRealm
    {
        string GetName();
        bool Supports(IAuthenticationToken token);
        IAuthenticationInfo GetAuthenticationInfo(IAuthenticationToken token);
    }
}
