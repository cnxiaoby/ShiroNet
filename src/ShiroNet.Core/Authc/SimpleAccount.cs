using System;
using System.Collections.Generic;
using System.Text;
using ShiroNet.Authz;
using ShiroNet.Subject;

namespace ShiroNet.Authc
{
    public class SimpleAccount : IAccount, IMergableAuthenticationInfo, ISaltedAuthenticationInfo
    {
        public object Credentials => throw new NotImplementedException();

        public IPrincipalCollection Principals => throw new NotImplementedException();

        public ICollection<IPermission> ObjectPermissions => throw new NotImplementedException();

        public ICollection<string> Roles => throw new NotImplementedException();

        public ICollection<string> StringPermissions => throw new NotImplementedException();

        public ByteSource CredentialsSalt => throw new NotImplementedException();

        public void Merge(IAuthenticationInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
