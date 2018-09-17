using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShiroNet.Util
{
    public class SimpleByteSource : IByteSource
    {
        private String cachedHex;
        private String cachedBase64;

        private byte[] bytes;
        public byte[] Bytes
        {
            get
            {
                return this.bytes;
            }
        }

        #region 构造函数
        public SimpleByteSource(byte[] bytes)
        {
            this.bytes = bytes;
        }

        public SimpleByteSource(char[] chars)
        {
            this.bytes = CodecSupport.toBytes(chars);
        }

        public SimpleByteSource(string str)
        {
            this.bytes = CodecSupport.toBytes(str);
        }

        public SimpleByteSource(IByteSource source)
        {
            this.bytes = source.Bytes;
        }

        public SimpleByteSource(Stream stream)
        {
            this.bytes = new BytesHelper().getBytes(stream);
        }
        #endregion

        public bool IsEmpty()
        {
            return this.bytes == null || this.bytes.Length == 0;
        }

        public string ToHex()
        {
            if (this.cachedHex == null)
            {
                this.cachedHex = Hex.encodeToString(Bytes);
            }
            return this.cachedHex;
        }

        public static bool IsCompatible(object o)
        {
            throw new NotImplementedException();
        }
  
        public String toBase64()
        {
            if (this.cachedBase64 == null)
            {
                this.cachedBase64 = Base64.encodeToString(Bytes);
            }
            return this.cachedBase64;
        }

        public String ToString()
        {
            return toBase64();
        }

        public int HashCode()
        {
            if (this.bytes == null || this.bytes.Length == 0)
            {
                return 0;
            }
            return Arrays.hashCode(this.bytes);
        }

        public bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (o instanceof IByteSource) {
                IByteSource bs = (IByteSource)o;
                return Arrays.equals(getBytes(), bs.getBytes());
            }
            return false;
        }

        //https://issues.apache.org/jira/browse/SHIRO-203
        private static class BytesHelper : CodecSupport
        {
            public byte[] getBytes(File file)
            {
                return toBytes(file);
            }

            public byte[] getBytes(InputStream stream)
            {
                return toBytes(stream);
            }
        }
    }
}
