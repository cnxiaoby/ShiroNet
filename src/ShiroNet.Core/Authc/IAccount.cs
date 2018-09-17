using ShiroNet.Authz;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface IAccount : IAuthenticationInfo, IAuthorizationInfo
    {

    }
}
