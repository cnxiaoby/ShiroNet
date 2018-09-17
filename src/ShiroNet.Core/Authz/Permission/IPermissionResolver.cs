using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    public interface IPermissionResolver
    {
        IPermission ResolvePermission(string permissionString);
    }
}
