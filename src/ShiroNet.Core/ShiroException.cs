using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet
{
    public class ShiroException : ApplicationException
    {
        public ShiroException()
        {
        }

        public ShiroException(string message) : base(message)
        {
        }

        public ShiroException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ShiroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
