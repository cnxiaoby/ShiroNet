using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Realm
{
    public interface IRealmFactory
    {
        ICollection<Realm> GetRealms();
    }
}
