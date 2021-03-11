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
            SqlCommand command = new SqlCommand("SELECT * FROM Users", Program.SqlConn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {   
                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",  
                        reader[0], reader[1], reader[2], reader[3]));
                }
            }
            return new Profile(username);
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
