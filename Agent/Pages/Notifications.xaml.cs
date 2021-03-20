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
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Page
    {
        public Notifications()
        {
            InitializeComponent();
        }

        public void CreateAndPlaceNotificationCard(Shared.ScientificProduction sp, Shared.Profile p)
        {
            Assets.NotificationCard notificationCard = new Assets.NotificationCard(sp, p);

            NotificationStack.Children.Add(notificationCard);
        }
    }
}
