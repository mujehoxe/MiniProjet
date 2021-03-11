using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    [Serializable]
    public class Profile
    {
        public Profile(object id, object fullname, object username, object teamid, object labid)
        {
            Id = (int)id;
            Fullname = (string)fullname;
            Username = (string)username;
            Teamid = (string)teamid;
            Labid = (string)labid;
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Teamid { get; set; }
        public string Labid { get; set; }

        
    }
    [Serializable]
    public class SientificProduction
    {
    }
}
