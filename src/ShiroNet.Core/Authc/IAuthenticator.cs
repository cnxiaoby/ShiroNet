using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface IAuthenticator
    {
        IAuthenticationInfo Authenticate(IAuthenticationToken token);
    }
}
