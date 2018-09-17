using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Authc
{
    public interface IHostAuthenticationToken: IAuthenticationToken
    {
        string Host { get; }
    }
}
