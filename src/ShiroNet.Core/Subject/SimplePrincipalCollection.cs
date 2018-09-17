using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShiroNet.Subject
{
    public class SimplePrincipalCollection : IMultiplePrincipalCollection
    {
        private string cachedToString;
        private Dictionary<string, HashSet<object>> realmPrincipals = new Dictionary<string, HashSet<object>>();

        public SimplePrincipalCollection()
        {
        }

        public SimplePrincipalCollection(object principal, string realmName)
        {
            if (principal is ICollection)
            {
                AddAll(principal as ICollection<object>, realmName);
            }
            else
            {
                Add(principal, realmName);
            }
        }

        public SimplePrincipalCollection(ICollection<object> principals, string realmName)
        {
            AddAll(principals, realmName);
        }

        public SimplePrincipalCollection(IPrincipalCollection principals)
        {
            AddAll(principals);
        }

        protected HashSet<object> GetPrincipalsLazy(String realmName)
        {
            HashSet<object> principals;
            if (realmPrincipals.ContainsKey(realmName))
            {
                principals = realmPrincipals[realmName];
            }
            else
            {
                principals = new HashSet<object>();

                realmPrincipals.Add(realmName, principals);
            }

            return principals;
        }

        public object GetPrimaryPrincipal()
        {
            if (IsEmpty() && !GetEnumerator().MoveNext())
            {
                return null;
            }
            return GetEnumerator().Current;
        }

        public object PrimaryPrincipal => throw new NotImplementedException();

        public ICollection<string> RealmNames => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(object principal, string realmName)
        {
            if (realmName == null)
            {
                throw new ArgumentNullException("realmName");
            }
            if (principal == null)
            {
                throw new ArgumentNullException("principal");
            }
            this.cachedToString = null;
            this.GetPrincipalsLazy(realmName).Add(principal);
        }

        public void AddAll(ICollection<object> principals, string realmName)
        {
            if (realmName == null)
            {
                throw new ArgumentNullException("realmName argument cannot be null.");
            }
            if (principals == null)
            {
                throw new ArgumentNullException("principals argument cannot be null.");
            }
            if (principals.Count == 0)
            {
                throw new ArgumentNullException("principals argument cannot be an empty collection.");
            }
            this.cachedToString = null;
            foreach(var principal in principals)
            {
                Add(principal, realmName);
            }
        }

        public void AddAll(IPrincipalCollection principals)
        {
            if (principals.RealmNames != null)
            {
                foreach (string realmName in principals.RealmNames)
                {
                    foreach (var principals in principals.FromRealm(realmName))
                    {
                        AddAll(principals, realmName);
                    }
                }
            }
        }

        public ICollection<object> AsCollection()
        {
            throw new NotImplementedException();
        }

        public IList<object> AsList()
        {
            throw new NotImplementedException();
        }

        public ICollection<T> ByType<T>()
        {
            if (realmPrincipals == null || realmPrincipals.Count == 0)
            {
                return new HashSet<T>();
            }

            var values = realmPrincipals.Values;
            if (values == null || values.Count == 0)
            {
                return new HashSet<T>();
            }

            var typed = new HashSet<T>();
            foreach (var set in values)
            {
                foreach (object o in set)
                {
                    if (o is T)
                    {
                        typed.Add((T)o);
                    }
                }
            }
            return typed;
        }

        public T OneByType<T>()
        {
            return ByType<T>().FirstOrDefault();
        }

        public void Clear()
        {
            realmPrincipals.Clear();
        }
        
        public ICollection<object> FromRealm(string realmName)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
