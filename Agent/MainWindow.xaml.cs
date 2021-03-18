using Shared;
using System;
using System.Runtime.Remoting;
using System.Windows;

namespace Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User User { get; set; }

        public NotifyImplementation Notifications { get; set; }

        public IAuthenticate AuthenticationObj { get; set; }
        public IResearcher PublishingObject { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            User = new Employee();
            Notifications = new NotifyImplementation();

            RemotingConfiguration.Configure("Agent.exe.config", false);

            AuthenticationObj = (IAuthenticate)Activator.GetObject(typeof(IAuthenticate), "tcp://localhost:8085/AuthenticationObj.rem");

            Notifications = new NotifyImplementation();
        }
    }
}
