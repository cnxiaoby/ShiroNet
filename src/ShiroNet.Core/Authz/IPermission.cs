using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz
{
    public interface IPermission
    {
        bool Implies(IPermission permission);
    }
}
