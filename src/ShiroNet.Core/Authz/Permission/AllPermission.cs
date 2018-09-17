using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz.Permission
{
    [Serializable]
    public class AllPermission : IPermission
    {
        public bool Implies(IPermission permission)
        {
            return true;
        }
    }
}
