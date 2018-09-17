using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class LockedAccountException : DisabledAccountException
    {
        public LockedAccountException()
        {
        }

        public LockedAccountException(string message) : base(message)
        {
        }

        public LockedAccountException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected LockedAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
