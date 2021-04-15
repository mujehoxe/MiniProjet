using System;
using System.Collections.Generic;

namespace Shared
{
    [Serializable]
    public class Notification
    {
        public string username;
        public string type;
        public string title;
    }

    [Serializable]
    public class Profile
    {
        public Profile(int id, string fullname, string username, string email, string field, int teamid)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            Email = email;
            Field = field;
            TeamId = teamid;
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Field { get; set; }
        public int TeamId { get; set; }

        public List<string> Roles { get; set; }
        public List<ScientificProduction> ScientificProductions { get; set; }

    }

    [Serializable]
    public class ScientificProduction
    {
        public ScientificProduction(string type, string title, string content)
        {
            Type = type;
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
