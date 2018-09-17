using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class CredentialsException : AuthenticationException
    {
        public CredentialsException()
        {
        }

        public CredentialsException(string message) : base(message)
        {
        }

        public CredentialsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
