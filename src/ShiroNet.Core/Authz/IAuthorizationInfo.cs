using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz
{
    public interface IAuthorizationInfo
    {
        ICollection<IPermission> ObjectPermissions { get; }

        ICollection<string> Roles { get; }

        ICollection<string> StringPermissions { get; }
    }
}
