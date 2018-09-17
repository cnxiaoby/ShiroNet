namespace ShiroNet.Authc
{
    public interface IAuthenticationToken
    {
        object Credentials { get; }
        object Principal { get; }
    }
}
