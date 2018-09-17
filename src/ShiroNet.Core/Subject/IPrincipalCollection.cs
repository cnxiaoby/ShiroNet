using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Subject
{
    public interface IPrincipalCollection : IEnumerable<IPrincipal>
    {
        int Count { get; }
        T OneByType<T>();
        ICollection<T> ByType<T>();
        IList<IPrincipal> AsList();
        ICollection<IPrincipal> AsCollection();
        ICollection<IPrincipal> FromRealm(string realmName);
        ICollection<string> RealmNames { get; }
        bool IsEmpty();
    }
}
