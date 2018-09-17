using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using log4net;
using System.Threading;
using ShiroNet.Mgt;

namespace ShiroNet.Util
{
    public class ThreadContext
    {
        private static ILoggerFactory loggerFactory = new LoggerFactory();
        private static ILogger logger = loggerFactory.CreateLogger<ThreadContext>();

        public static readonly string SECURITY_MANAGER_KEY = typeof(ThreadContext).Name + "_SECURITY_MANAGER_KEY";
        public static readonly string SUBJECT_KEY = typeof(ThreadContext).Name + "_SUBJECT_KEY";

        private static IDictionary<object, object> _Resources = new Dictionary<object, object>();
        public static IDictionary<object, object> Resources
        {
            get
            {
                return _Resources;
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    _Resources = value;
                }
            }
        }

        private static object GetValue(object key)
        {
            return Resources.ContainsKey(key) ? Resources[key] : null;
        }

        public static object Get(object key)
        {
            if (logger.IsEnabled(LogLevel.Trace))
            {
                string msg = "get() - in thread [" + Thread.CurrentThread.Name + "]";
                logger.LogTrace(msg);
            }

            object value = GetValue(key);
            if ((value != null) && logger.IsEnabled(LogLevel.Trace))
            {
                String msg = "Retrieved value of type [" + value.GetType().FullName + "] for key [" +
                        key + "] " + "bound to thread [" + Thread.CurrentThread.Name + "]";
                logger.LogTrace(msg);
            }
            return value;
        }

        public static void Put(object key, object value)
        {
            if (key == null)
            {
                throw new ArgumentException("key cannot be null");
            }

            if (value == null)
            {
                Remove(key);
                return;
            }

            Resources.Add(key, value);

            if (logger.IsEnabled(LogLevel.Trace))
            {
                String msg = "Bound value of type [" + value.GetType().FullName + "] for key [" +
                        key + "] to thread " + "[" + Thread.CurrentThread.Name + "]";
                logger.LogTrace(msg);
            }
        }

        public static object Remove(object key)
        {
            if (key == null)
            {
                throw new ArgumentException("key cannot be null");
            }

            object value = GetValue(key);

            Resources.Remove(key);

            if ((value != null) && logger.IsEnabled(LogLevel.Trace))
            {
                String msg = "Removed value of type [" + value.GetType().FullName + "] for key [" +
                        key + "] to thread " + "[" + Thread.CurrentThread.Name + "]";
                logger.LogTrace(msg);
            }

            return value;
        }

        public static void Remove() 
        {
            Resources.Clear();
        }

        public static ISecurityManager GetSecurityManager()
        {
            return (ISecurityManager)Get(SECURITY_MANAGER_KEY);
        }
    }
}
