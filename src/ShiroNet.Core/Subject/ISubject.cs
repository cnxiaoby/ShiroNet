using ShiroNet.Authz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShiroNet.Subject
{
    public interface ISubject
    {
        object getPrincipal();
        IPrincipalCollection getPrincipals();

        bool isPermitted(string permission);
        bool isPermitted(IPermission permission);
        bool[] isPermitted(params string[] permissions);
        bool[] isPermitted(IEnumerable<IPermission> permissions);

        bool isPermittedAll(params string[] permissions);
        bool isPermittedAll(IEnumerable<IPermission> permissions);

        void checkPermission(string permission);
        void checkPermission(IPermission permission);
        void checkPermissions(params string[] permissions);
        void checkPermissions(IEnumerable<IPermission> permissions);

        bool hasRole(string roleIdentifier);
        bool[] hasRoles(IEnumerable<string> roleIdentifiers);

        bool hasAllRoles(IEnumerable<string> roleIdentifiers);

        void checkRole(string roleIdentifier);
        void checkRoles(IEnumerable<string> roleIdentifiers);
        void checkRoles(params string[] roleIdentifiers);

        void login(AuthenticationToken token);

        bool isAuthenticated();
        bool isRemembered();

        Session getSession();
        Session getSession(bool create);

        void logout();

        V execute<V>(Task<V> callable);

        void execute(RunnableDelegate runnable);
    }
}
