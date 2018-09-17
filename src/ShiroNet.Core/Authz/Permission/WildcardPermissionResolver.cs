using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    public class WildcardPermissionResolver : IPermissionResolver
    {
        public IPermission ResolvePermission(string permissionString)
        {
            return new WildcardPermission(permissionString);
        }
    }
}
