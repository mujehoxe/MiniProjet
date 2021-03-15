using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        public IUser User { get; set; }
        public TcpChannel Channel { get; set; }
        public IAuthenticate AuthenticationObject { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            User = new Employee();
            //MainFrame.Navigate(new Pages.Login());
            MainFrame.Navigate(new Pages.Dash());

            Channel = new TcpChannel();
            ChannelServices.RegisterChannel(Channel, false);
            AuthenticationObject = (IAuthenticate)Activator.GetObject(typeof(IAuthenticate), "tcp://localhost:8085/obj");
        }
    }
}
