using ShiroNet.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authz
{
    public interface IAuthorizer
    {
        bool IsPermitted(IPrincipalCollection principals, string permission);
        bool IsPermitted(IPrincipalCollection subjectPrincipal, IPermission permission);
        bool[] IsPermitted(IPrincipalCollection subjectPrincipal, params string[] permissions);
        bool[] IsPermitted(IPrincipalCollection subjectPrincipal, ICollection<IPermission> permissions);

        bool IsPermittedAll(IPrincipalCollection subjectPrincipal, params string[] permissions);
        bool IsPermittedAll(IPrincipalCollection subjectPrincipal, ICollection<IPermission> permissions);

        void CheckPermission(IPrincipalCollection subjectPrincipal, string permission);
        void CheckPermission(IPrincipalCollection subjectPrincipal, IPermission permission);
        void CheckPermission(IPrincipalCollection subjectPrincipal, params string[] permission);
        void CheckPermission(IPrincipalCollection subjectPrincipal, ICollection<IPermission> permission);

        bool HasRole(IPrincipalCollection subjectPrincipal, string roleIdentifier);
        bool[] HasRole(IPrincipalCollection subjectPrincipal, ICollection<string> roleIdentifier);
        bool HasAllRoles(IPrincipalCollection subjectPrincipal, ICollection<string> roleIdentifier);

        void CheckRole(IPrincipalCollection subjectPrincipal, string roleIdentifier);
        void CheckRole(IPrincipalCollection subjectPrincipal, ICollection<string> roleIdentifier);
        void CheckRole(IPrincipalCollection subjectPrincipal, params string[] roleIdentifier);
    }
}
