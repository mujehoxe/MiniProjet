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


        public void InformNewProduction(ScientificProduction sp, Profile researcher)
        {
            Console.WriteLine("{0} \t {1} \t {2} \t {3}", researcher.Fullname,sp.Content, sp.Title, sp.Type);

            //notificationsPage.CreateAndPlaceNotificationCard(sp, researcher);
        }
    }
}
