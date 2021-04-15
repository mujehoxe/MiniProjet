using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Controls;

namespace Agent.Pages
{
    public partial class Notifications : Page
    {        
        public List<Shared.Notification> notifications;
        private List<Shared.Notification> old_notifications;

        private Timer timer;

        public Notifications()
        {
            InitializeComponent();
            InitializeTimer();

            notifications = new List<Shared.Notification>();
            old_notifications = new List<Shared.Notification>();
        }

        public void CreateAndPlaceNotificationCard(Shared.Notification notification)
        {
            Assets.NotificationCard notificationCard = new Assets.NotificationCard(notification.username, notification.title, notification.type);

            NotificationStack.Children.Add(notificationCard);
        }

        private void Update()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                {
                    NotificationStack.Children.Clear();
                    foreach (var notification in notifications)
                        CreateAndPlaceNotificationCard(notification);
                }
            );   
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Interval = 10000;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (NotificationsChanged())
            {
                UpdateOldNotifications();
                this.Update();
            }
        }

        private void UpdateOldNotifications()
        {
            old_notifications = notifications;
        }

        private bool NotificationsChanged()
        {
            return !old_notifications.SequenceEqual(notifications);
        }
    }
}
