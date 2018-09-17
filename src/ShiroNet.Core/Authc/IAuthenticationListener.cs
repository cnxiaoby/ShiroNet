using ShiroNet.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface IAuthenticationListener
    {
        void OnSuccess(IAuthenticationToken token, IAuthenticationInfo info);

        void OnFailure(IAuthenticationToken token, AuthenticationException ae);
        
        void OnLogout(IPrincipalCollection principals);
    }
}
