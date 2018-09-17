using ShiroNet.Authc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Mgt
{
    public interface ISecurityManager : IAuthenticator, IAuthorizer, ISessionManager
    {
    }
}
