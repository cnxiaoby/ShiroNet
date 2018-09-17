using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Cache
{
    public class CacheException : ShiroException
    {
        public CacheException()
        {
        }

        public CacheException(string message) : base(message)
        {
        }

        public CacheException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CacheException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
