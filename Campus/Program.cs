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

            /*IAuthenticate obj = (IAuthenticate) new ImplementAuthentication();
            Profile profile = obj.Login("oussama", "oussama");
            if (profile != null)
                Console.WriteLine("{0} \t | {1} \t | {2} \t |\t {3}|\t {4}|\t {5}", profile.Id, profile.Fullname, profile.Username, profile.Email, profile.Field, profile.TeamId);
            else
                Console.WriteLine("wrong credentials");*/
            
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
