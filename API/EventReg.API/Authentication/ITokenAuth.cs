namespace EventReg.API.Authentication
{
    public interface ITokenAuth
    {
        string Authentication(string username, string password);
    }
}
