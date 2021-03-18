using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Configuration;
using System.Runtime.Remoting.Channels.Http;
using Microsoft.Data.Sqlite;
using Shared;


namespace Campus
{
    static class Program
    {
        public static SqliteConnection SqlConn { get; set; }

        static void Main(string[] args)
        {
            TcpChannel ch = new TcpChannel(8085);
            ChannelServices.RegisterChannel(ch, false);

            OpenDatabaseConnection();
            
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ImplementAuthentication),
                                                               "obj",
                                                             WellKnownObjectMode.Singleton);

            Console.WriteLine("Sever is  Ready........");
            Console.Read();
            SqlConn.Close();
        }

        private static void OpenDatabaseConnection() 
        {
            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                SqlConn = new SqliteConnection(connectionString);

                SqlConn.Open();
                Console.WriteLine("Database connection " + SqlConn.State);
            }
            catch
            {
                Console.WriteLine("Database connection failed");
            }
        }
    }
}
