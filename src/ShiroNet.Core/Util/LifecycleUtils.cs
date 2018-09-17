using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Util
{
    public class LifecycleUtils
    {
        private static ILoggerFactory loggerFactory = new LoggerFactory();
        private static ILogger logger = loggerFactory.CreateLogger<ThreadContext>();

        public static void Init(object o)
        {
            if (o is IInitializable)
            {
                Init((IInitializable)o);
            }
        }

        public static void Init(ICollection<object> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                return;
            }

            foreach (object o in collection)
            {
                Init(o);
            }
        }

        public static void Init(IInitializable initializable)
        {
            if (initializable != null)
            {
                initializable.Init();
            }
        }

        public static void Dispose(object o)
        {
            if (o is IDisposable)
            {
                Dispose((IDisposable)o);
            }
            else if (o is ICollection<object>) {
                Dispose((ICollection<object>)o);
            }
        }

        public static void Dispose(IDisposable disposable)
        {
            if (disposable != null)
            {
                try
                {
                    disposable.Dispose();
                }
                catch (Exception ex)
                {
                    if (logger.IsEnabled(LogLevel.Debug))
                    {
                        String msg = "Unable to cleanly destroy instance [" + disposable + "] of type [" + disposable.GetType().FullName + "].";
                        logger.LogDebug(msg, ex);
                    }
                }
            }
        }

        public static void Dispose(ICollection<object> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                return;
            }

            foreach (object o in collection)
            {
                Dispose(o);
            }
        }
    }
}
