using ShiroNet.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface IAuthenticationInfo
    {
        object Credentials { get; }

        IPrincipalCollection Principals { get; }
    }
}
