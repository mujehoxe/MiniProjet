using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IAuthenticate
    {
        IUser Login(string username, string password, INotify client);
        bool Logout();
        bool Verify_User(string password);
    }
}
