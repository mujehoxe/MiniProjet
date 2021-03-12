using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campus
{
    class ImplementAuthentication : MarshalByRefObject, IAuthenticate
    {
        public Profile Login(string username, string password)
        {
            Console.WriteLine("loging in with " + username + password);
            
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                SELECT id, UserName, FullName, TeamID, LabID
                FROM user
                WHERE username = $id and password = $password
            ";
            command.Parameters.AddWithValue("$username", username);
            command.Parameters.AddWithValue("$password", password);
            
            using (var  reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                     return new Profile(reader[0], reader[1], reader[2], reader[3], reader[4]);
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
