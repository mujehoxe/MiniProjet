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
            
        }

        public void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Password;

            var mainwindow = (Application.Current.MainWindow as MainWindow);
            IUser a = (IUser) mainwindow.User;
            a.Login(username, password);

            mainwindow.MainFrame.Navigate(new Pages.Dash());
        }
    }
}
