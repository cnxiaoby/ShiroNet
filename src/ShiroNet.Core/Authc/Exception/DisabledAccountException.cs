using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class DisabledAccountException : AccountException
    {
        public DisabledAccountException()
        {
        }

        public DisabledAccountException(string message) : base(message)
        {
        }

        public DisabledAccountException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected DisabledAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
