using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    [Serializable]
    public class Profile
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Teamid { get; set; }
        public string Labid { get; set; }

        public Profile(string username)
        {
            Username = username;
        }
    }
    [Serializable]
    public class SientificProduction
    {
    }
}
