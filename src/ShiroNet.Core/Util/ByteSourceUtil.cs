using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShiroNet.Util
{
    public class ByteSourceUtil
    {
        public static IByteSource Bytes(byte[] bytes)
        {
            return new SimpleByteSource(bytes);
        }

        public static IByteSource bytes(char[] chars)
        {
            return new SimpleByteSource(chars);
        }

        public static IByteSource Bytes(string str)
        {
            return new SimpleByteSource(str);
        }

        public static IByteSource Bytes(IByteSource source)
        {
            return new SimpleByteSource(source);
        }

        public static IByteSource Bytes(Stream stream)
        {
            return new SimpleByteSource(stream);
        }

        public static bool IsCompatible(Object source)
        {
            return SimpleByteSource.IsCompatible(source);
        }

        public static byte[] Bytes(object source)
        {
            if (source == null)
            {
                return null;
            }
            if (!IsCompatible(source))
            {
                String msg = "Unable to heuristically acquire bytes for object of type [" +
                        source.GetType().FullName + "].  If this type is indeed a byte-backed data type, you might " +
                        "want to write your own IByteSource implementation to extract its bytes explicitly.";
                throw new ArgumentException(msg);
            }
            if (source is byte[]) {
                return bytes((byte[])source);
            } else if (source is IByteSource) {
                return ((IByteSource)source).Bytes;
            } else if (source is char[]) {
                return bytes((char[])source);
            } else if (source is String) {
                return bytes((String)source);
            } else if (source is Stream) {
                return bytes((Stream)source);
            } else {
                throw new ArgumentException("Encountered unexpected byte source.  This is a bug - please notify " +
                        "the Shiro developer list asap (the isCompatible implementation does not reflect this " +
                        "method's implementation).");
            }
        }
    }
}
