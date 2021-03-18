using Shared;
using System;
using System.Collections;
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
            Profile p = ReadDataReturnProfile(command);

            if (p != null)
            {
                command = QueryUserRoles(p.Id);
                p.Roles = ReadRoles(command);
                command = QueryUserProducions(p.Id);
                p.ScientificProductions = ReadProductions(command);
            }
            return p;
        }

        private List<ScientificProduction> ReadProductions(SqliteCommand command)
        {
            List<ScientificProduction> productions = new List<ScientificProduction>();
            ScientificProduction sc;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    sc = new ScientificProduction(
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    );
                    productions.Add(sc);
                }
            }
            return productions;
        }

        private SqliteCommand QueryUserProducions(int userId)
        {
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                select *
                from scientific_productions sp
                where (
                    select Id
                    from employee
                    where Id = $userId
                ) = sp.ResearcherId
            ";
            command.Parameters.AddWithValue("$userId", userId);
            return command;
        }

        private List<string> ReadRoles(SqliteCommand command)
        {
            List<string> roles = new List<string>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    roles.Add(reader.GetString(1));
                }
            }
            return roles;
        }

        private SqliteCommand QueryUserRoles(int userId)
        {
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                select *
                from employees_role er
                where (
                    select Id
                    from employee
                    where Id = $userId
                ) = er.EmployeeId
            ";
            command.Parameters.AddWithValue("$userId", userId);
            return command;
        }

        private static SqliteCommand QueryUser(string username, string password)
        {
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                select Id, Fullname, Username, Email, Field ,TeamID
                from employee
                where Username = $username and Password = $password
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
                    return new Profile(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetInt32(5)
                    );
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
