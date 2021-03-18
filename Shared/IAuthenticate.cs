namespace Shared
{
    public interface IAuthenticate
    {
        IResearcher Login(string username, string password, INotify client);
        bool Logout();
        bool Verify_User(string password);
    }
}
