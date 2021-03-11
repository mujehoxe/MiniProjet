using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    public interface IUser
    {
        int Login(string username, string password);
    }

    public class Employee : IUser
    {
        private string fullName;
        private Researcher researcher;
        private Director Director;
        
        public int Login(string username, string password)
        {
            Debug.WriteLine("loging with " + username + password);
            return 1;
        }
    }

    class Researcher
    {
        private string teamid;
     
    }

    class Lead : Researcher
    {
        
    }

    class Manager
    {
        private string labid;
    }
}
