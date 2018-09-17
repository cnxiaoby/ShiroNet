using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class ExcessiveAttemptsException : AccountException
    {
        public ExcessiveAttemptsException()
        {
        }

        public ExcessiveAttemptsException(string message) : base(message)
        {
        }

        public ExcessiveAttemptsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ExcessiveAttemptsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
