using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface IMergableAuthenticationInfo: IAuthenticationInfo
    {
        void Merge(IAuthenticationInfo info);
    }
}
