using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compus
{
    class ImplementAuthentication : MarshalByRefObject, IAuthenticate
    {
        public Profile Login(string username, string password)
        {
            Console.WriteLine("loging in with " + username + password);
            string query = "SELECT id, UserName, FullName, TeamID, LabID " +
                "FROM Users " +
                "Where (username='" + username + "' and hash='" + password + "')";
                ;

            SqlCommand command = new SqlCommand(query, Program.SqlConn);

            using (SqlDataReader reader = command.ExecuteReader())
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
