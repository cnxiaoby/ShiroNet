using System;
using System.Collections.Generic;
using System.Text;
using ShiroNet.Subject;

namespace ShiroNet.Authc
{
    public abstract class AbstractAuthenticator : IAuthenticator, ILogoutAware
    {
        public IAuthenticationInfo Authenticate(IAuthenticationToken token)
        {
            throw new NotImplementedException();
        }

        public void OnLogout(IPrincipalCollection principals)
        {
            throw new NotImplementedException();
        }
    }
}
