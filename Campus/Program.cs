using Microsoft.Data.Sqlite;
using System;
using System.Configuration;
using System.Runtime.Remoting;


namespace Campus
{
    static class Program
    {
        public static SqliteConnection SqlConn { get; set; }
        public static ImplementAuthentication AuthenticationObj { get; set; }

        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Campus.exe.config", false);

            AuthenticationObj = new ImplementAuthentication();
            RemotingServices.Marshal(AuthenticationObj, "AuthenticationObj.rem", typeof(ImplementAuthentication));

            foreach (var service in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
                Console.WriteLine(service);

            OpenDatabaseConnection();

            Console.WriteLine("server running...");
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
