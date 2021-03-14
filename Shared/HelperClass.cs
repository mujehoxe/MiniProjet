using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    [Serializable]
    public class Profile
    {
        public Profile(object id, object fullname, object username, object email, object field, object teamid)
        {
            Id = (long) id;
            Fullname = (string) fullname;
            Username = (string) username;
            Email = (string) email;
            Field = (string) field;
            TeamId = (long) teamid;
            
        }

        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Field { get; set; }
        public long TeamId { get; set; }
    }
    
    [Serializable]
    public class ScientificProduction
    {
        public ScientificProduction(object title, object type, object content)
        {
            Title = (string) title;
            Type = (string) title;
            Content = (string) title;
        }
        
        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
