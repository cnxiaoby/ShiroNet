using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    public interface IRolePermissionResolver
    {
        ICollection<IPermission> ResolvePermissionsInRole(string roleString);
    }
}
