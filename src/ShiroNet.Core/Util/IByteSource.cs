using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Util
{
    public interface IByteSource
    {
        byte[] Bytes { get; }
        string ToHex();
        bool IsEmpty();        
    }
}
