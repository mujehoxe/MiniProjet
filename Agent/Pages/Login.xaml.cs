using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agent.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            Username.Focus();
            Username.Select(0, Username.Text.Length);
        }

        public void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;

            var mainWindow = (Application.Current.MainWindow as MainWindow);

            try
            {
                Shared.IAuthenticate authenticationObj = mainWindow.DistantObject as Shared.IAuthenticate;
                Shared.IResearcher researcher = authenticationObj.Login(username, password, mainWindow.Notifications);
                if (researcher != null)
                {
                    Shared.Profile profile = researcher.RetriveProfile();

                    Console.WriteLine("{0} \t | {1} \t | {2} \t |\t {3}|\t {4}|\t {5}", profile.Id, profile.Fullname,
                        profile.Username, profile.Email, profile.Field, profile.TeamId);

                    mainWindow.MainFrame.Navigate(new Pages.Dash(profile));
                    
                    mainWindow.User.Profile = profile;
                }
                else
                {
                    Console.WriteLine("Wrong credentials");

                    Pages.LoginPage p = mainWindow.MainFrame.Content as Pages.LoginPage;
                    p.SetPasswordBox("");
                    p.SetErrors("Wrong credentials, try oussama oussama");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Pages.LoginPage p = mainWindow.MainFrame.Content as Pages.LoginPage;
                p.SetErrors(ex.Message);
            }
        }

        public void SetUsernameBox(string username)
        {
            this.Username.Text = username;
        }
        public void SetPasswordBox(string password)
        {
            this.Password.Password = password;
        }
        public void SetErrors(string errors)
        {
            this.Errors.Text = errors;
        }
    }
}
