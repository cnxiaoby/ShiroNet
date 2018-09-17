using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class ConcurrentAccessException : AccountException
    {
        public ConcurrentAccessException()
        {
        }

        public ConcurrentAccessException(string message) : base(message)
        {
        }

        public ConcurrentAccessException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ConcurrentAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
