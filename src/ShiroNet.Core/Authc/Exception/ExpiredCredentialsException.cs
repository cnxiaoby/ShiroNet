using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class ExpiredCredentialsException : CredentialsException
    {
        public ExpiredCredentialsException()
        {
        }

        public ExpiredCredentialsException(string message) : base(message)
        {
        }

        public ExpiredCredentialsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ExpiredCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
