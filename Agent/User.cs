using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Shared;


namespace Agent
{
    public interface IUser
    {
        void Login(string username, string password);
    }

    public class Employee : IUser
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Teamid { get; set; }
        public string Labid { get; set; }

        private Profile profile;
        private Researcher researcher;
        private Manager manager;
        
        public void Login(string username, string password)
        {
            Debug.WriteLine("loging with " + username + password);
            this.profile = (Application.Current.MainWindow as MainWindow).AuthenticationObject.Login(username, password);
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
