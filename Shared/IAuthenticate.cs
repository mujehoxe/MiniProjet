using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IAuthenticate
    {
        Profile Login(string username, string password);
        bool Logout();
        bool Verify_User(string password);
    }
}
