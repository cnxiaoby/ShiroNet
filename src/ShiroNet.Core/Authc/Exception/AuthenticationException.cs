using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class AuthenticationException : ShiroException
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string message) : base(message)
        {
        }

        public AuthenticationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected AuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
