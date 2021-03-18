using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
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

namespace Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User User { get; set; }
        public NotifyImplementation Notifications { get; set; }

        public HttpChannel Channel { get; set; }
        public MarshalByRefObject DistantObject { get; set; }
        public IResearcher PublishingObject { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            User = new Employee();
            Notifications = new NotifyImplementation();

            Channel = new HttpChannel(0);
            ChannelServices.RegisterChannel(Channel, false);
            DistantObject = (MarshalByRefObject) RemotingServices.Connect(typeof(IAuthenticate),
                "http://localhost:8085/obj");
        }
    }
}
