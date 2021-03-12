using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Configuration;
using Microsoft.Data.Sqlite;


namespace Campus
{
    static class Program
    {
        public static SqliteConnection SqlConn { get; set; }

        static void Main(string[] args)
        {
            TcpChannel ch = new TcpChannel(8085);
            ChannelServices.RegisterChannel(ch, false);

            string connectionString = "Data Source=C:/Users/o/source/repos/MiniProjet/miniprojdb";
            SqlConn = new SqliteConnection(connectionString);

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
