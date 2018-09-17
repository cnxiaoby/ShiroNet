using System;
using System.Collections.Generic;
using System.Text;
using ShiroNet.Subject;
using ShiroNet.Util;

namespace ShiroNet.Authc
{
    class SimpleAuthenticationInfo : IMergableAuthenticationInfo, ISaltedAuthenticationInfo
    {
        protected IPrincipalCollection principals;
        protected object credentials;
        protected IByteSource credentialsSalt;

        /**
         * Default no-argument constructor.
         */
        public SimpleAuthenticationInfo()
        {
        }
        public SimpleAuthenticationInfo(object principal, object credentials, string realmName)
        {
            this.principals = new SimplePrincipalCollection(principal, realmName);
            this.credentials = credentials;
        }

        public object Credentials
        {
            get { return this.credentials; }
        }

        public IPrincipalCollection Principals
        {
            get { return this.principals; }
        }
        public IByteSource CredentialsSalt
        {
            get { return this.credentialsSalt; }
        }

        public void Merge(IAuthenticationInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
