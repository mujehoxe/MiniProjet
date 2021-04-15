using Shared;
using System;
using System.Windows.Controls;

namespace Agent
{
    public class NotifyImplementation : MarshalByRefObject, Shared.INotify
    {
        private MainWindow mainWindow;
        private Pages.Notifications notificationsPage;


        public NotifyImplementation(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void RegisterNotificationsPage(Pages.Notifications notificationsPage)
        {
            this.notificationsPage = notificationsPage;
        }


        public void InformNewProduction(Notification notification)
        {
            Console.WriteLine("{0} has published {1} under the title {2}", notification.username, notification.type, notification.title);

            //notificationsPage.CreateAndPlaceNotificationCard(sp, researcher);

            notificationsPage.notifications.Add(notification);
        }
    }
}
