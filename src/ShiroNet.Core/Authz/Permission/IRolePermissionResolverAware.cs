using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    public interface IRolePermissionResolverAware
    {
        void SetRolePermissionResolver(IRolePermissionResolver rpr);
    }
}
