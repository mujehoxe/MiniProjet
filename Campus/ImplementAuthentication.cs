using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Campus
{
    class ImplementAuthentication : MarshalByRefObject, IAuthenticate
    {
        public Profile Login(string username, string password)
        {
            Console.WriteLine("loging in with " + username + password);
            
            var command = QueryUser(username, password);

            return ReadDataReturnProfile(command);
        }

        private static SqliteCommand QueryUser(string username, string password)
        {
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                SELECT Id, Fullname, Username, Email, Field ,TeamID
                FROM employee
                WHERE Username = $username and Password = $password
            ";
            command.Parameters.AddWithValue("$username", username);
            command.Parameters.AddWithValue("$password", password);
            return command;
        }

        private static Profile ReadDataReturnProfile(SqliteCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Profile(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                }
                return null;
            }
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }
        
        public bool Verify_User(string password)
        {
            throw new NotImplementedException();
        }
    }
}
