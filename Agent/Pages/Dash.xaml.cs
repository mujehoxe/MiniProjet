using System;
using System.Windows;
using System.Windows.Controls;

namespace Agent.Pages
{
    /// <summary>
    /// Interaction logic for Dash.xaml
    /// </summary>
    public partial class Dash : Page
    {
        public Pages.Profile profilePage;
        public Pages.Notifications notificationsPage;

        public Dash(Shared.Profile profile)
        {
            InitializeComponent();
            this.profilePage = new Pages.Profile(profile);
            this.notificationsPage = new Pages.Notifications();
            (Application.Current.MainWindow as MainWindow).Notifications.RegisterNotificationsPage(notificationsPage);

            ProfileFrame.Navigate(this.profilePage);
        }

        private void ProfileLableClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            ProfileFrame.Navigate(this.profilePage);
        }
        private void NotificationsLableClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            ProfileFrame.Navigate(this.notificationsPage);
        }

    }
}
