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
            RemotingConfiguration.Configure("Campus.exe.config", false);
            ImplementAuthentication authenticationObj = new ImplementAuthentication();
            RemotingServices.Marshal(authenticationObj, "AuthenticationObj.rem", typeof(ImplementAuthentication));

            OpenDatabaseConnection();
            

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
