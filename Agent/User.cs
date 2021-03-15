using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

			var mainWindow = (Application.Current.MainWindow as MainWindow);
            
            try
            {
                this.profile = mainWindow.AuthenticationObject.Login(username, password);
                if (this.profile != null)
                {
                    Console.WriteLine("{0} \t | {1} \t | {2} \t |\t {3}|\t {4}|\t {5}", profile.Id, profile.Fullname,
                        profile.Username, profile.Email, profile.Field, profile.TeamId);

                    mainWindow.MainFrame.Navigate(new Pages.Dash(this.profile));
                }
                else
                {
					Console.WriteLine("Wrong credentials");

                    Pages.LoginPage p = mainWindow.MainFrame.Content as Pages.LoginPage;
                    p.SetPasswordBox("");
                    p.SetErrors("Wrong credentials, try oussama oussama");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                Pages.LoginPage p = mainWindow.MainFrame.Content as Pages.LoginPage;
                p.SetErrors(e.Message);
            }
        }
    }

    public class Researcher
    {
        private List<ScientificProduction> ScientificProductions;
        private string Field;
    }

    public class Lead : Researcher
    {
        
    }

    public class Manager
    {
        
    }
}
