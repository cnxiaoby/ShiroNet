using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authz.Exception
{
    public class UnauthenticatedException : AuthorizationException
    {
        public UnauthenticatedException()
        {
        }

        public UnauthenticatedException(string message) : base(message)
        {
        }

        public UnauthenticatedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthenticatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
