using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class UnknownAccountException : AccountException
    {
        public UnknownAccountException()
        {
        }

        public UnknownAccountException(string message) : base(message)
        {
        }

        public UnknownAccountException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
