using ShiroNet.Authz.Permission;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz
{
    public class ModularRealmAuthorizer: IAuthorizer, IPermissionResolverAware, IRolePermissionResolverAware
    {
        protected ICollection<Realm> realms;
    }
}
