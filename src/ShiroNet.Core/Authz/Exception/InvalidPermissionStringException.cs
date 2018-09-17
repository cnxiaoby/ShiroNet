using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ShiroNet.Authz.Exception
{
    public class InvalidPermissionStringException : ShiroException
    {
        private String permissionString;

        public InvalidPermissionStringException()
        {
        }

        public InvalidPermissionStringException(string message) : base(message)
        {
        }

        public InvalidPermissionStringException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPermissionStringException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidPermissionStringException(string message, string permissionString) : base(message)
        {
            this.permissionString = permissionString;
        }

        public string GetPermissionString()
        {
            return this.permissionString;
        }
    }
}
