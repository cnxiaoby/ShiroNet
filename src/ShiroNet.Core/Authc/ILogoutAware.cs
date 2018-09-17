using ShiroNet.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface ILogoutAware
    {
        void OnLogout(IPrincipalCollection principals);
    }
}
