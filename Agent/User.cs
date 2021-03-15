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
        public string TeamId { get; set; }

        private Profile profile;
        
        private Researcher researcher;
        private Manager manager;
        
        public void Login(string username, string password)
        {
            Debug.WriteLine("loging with " + username + password);
            this.profile = (Application.Current.MainWindow as MainWindow).AuthenticationObject.Login(username, password);
            try
            {
                if (this.profile != null)
                {
                    Console.WriteLine("{0} \t | {1} \t | {2} \t |\t {3}|\t {4}|\t {5}", profile.Id, profile.Fullname,
                        profile.Username, profile.Email, profile.Field, profile.TeamId);

                    (Application.Current.MainWindow as MainWindow).MainFrame.Navigate(new Pages.Dash(this.profile));
                }
                else
                {
                    Console.WriteLine("Wrong credentials");
                    Pages.LoginPage p = new Pages.LoginPage();
                    p.usernameBox.Text = username;
                    p.Errors.Text = "wrong credentials, try oussama oussama";
                    (Application.Current.MainWindow as MainWindow).MainFrame.Navigate(p);
                }
            }
            catch
            {
                Console.WriteLine(e.Message);
                Pages.LoginPage p = new Pages.LoginPage();
                p.usernameBox.Text = username;
                p.Errors.Text = e.Message;
                (Application.Current.MainWindow as MainWindow).MainFrame.Content = p;
            }
        }
    }

    class Researcher
    {
        private List<ScientificProduction> ScientificProductions;
    }

    class Lead : Researcher
    {
        
    }

    class Manager
    {
        
    }
}
