using ShiroNet.Mgt;
using ShiroNet.Subject;
using ShiroNet.Util;
using System;

namespace ShiroNet
{
    public class SecurityUtils
    {
        private static ISecurityManager securityManager;

        public static ISubject GetSubject()
        {
            ISubject subject = ThreadContext.GetSubject();
            if (subject == null)
            {
                subject = (new Subject.Builder()).buildSubject();
                ThreadContext.bind(subject);
            }
            return subject;
        }
    }
}
