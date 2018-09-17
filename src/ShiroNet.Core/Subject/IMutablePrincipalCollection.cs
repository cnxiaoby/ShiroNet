using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Subject
{
    public interface IMultiplePrincipalCollection : IPrincipalCollection
    {
        void Add(object principal, String realmName);
        void AddAll(ICollection<object> principals, string realmName);
        void AddAll(IPrincipalCollection principals);
    }
}
