using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authz.Exception
{
    public class HostUnauthorizedException : UnauthorizedException
    {
        public HostUnauthorizedException()
        {
        }

        public HostUnauthorizedException(string message) : base(message)
        {
        }

        public HostUnauthorizedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected HostUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
