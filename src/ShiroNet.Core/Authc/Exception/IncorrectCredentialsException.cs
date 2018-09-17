using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authc.Exception
{
    public class IncorrectCredentialsException : CredentialsException
    {
        public IncorrectCredentialsException()
        {
        }

        public IncorrectCredentialsException(string message) : base(message)
        {
        }

        public IncorrectCredentialsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
