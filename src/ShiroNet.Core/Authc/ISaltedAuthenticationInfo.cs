using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface ISaltedAuthenticationInfo : IAuthenticationInfo
    {
        ByteSource CredentialsSalt { get; }
    }
}
