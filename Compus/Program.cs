using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Data.SqlClient;
using System.Configuration;

namespace Compus
{
    class Program
    {
        public static SqlConnection SqlConn { get; set; }

        static void Main(string[] args)
        {
            TcpChannel ch = new TcpChannel(8085);
            ChannelServices.RegisterChannel(ch, false);

            SqlConn = new SqlConnection();

            SqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["Compus.Properties.Settings.Database1ConnectionString"].ConnectionString;
            
            SqlConn.Open();

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ImplementAuthentication),
                                                               "obj",
                                                             WellKnownObjectMode.Singleton);

            Console.Write("Sever is  Ready........");
            Console.Read();
            SqlConn.Close();
        }
    }
}
