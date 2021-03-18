using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IAuthenticate
    {
        IResearcher Login(string username, string password, INotify client);
        bool Logout();
        bool Verify_User(string password);
    }
}
