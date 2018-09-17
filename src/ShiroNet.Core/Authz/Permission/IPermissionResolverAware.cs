using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    public interface IPermissionResolverAware
    {
        void SetPermissionResolver(IPermissionResolver pr);
    }
}
