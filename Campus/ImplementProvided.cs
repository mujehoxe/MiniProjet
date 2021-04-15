using Shared;
using System;
using System.Collections.Generic;

namespace Campus
{
    public class ImplementResearcher : MarshalByRefObject, Shared.IResearcher
    {
        public ImplementResearcher(Profile profile)
        {
            Profile = profile;
        }

        private Profile Profile;

        public Profile RetrieveProfile()
        {
            Console.WriteLine("retrieving profile");
            return Profile;
        }

        public bool ModifyProfile(Profile profile)
        {
            throw new System.NotImplementedException();
        }

        public string PublishScientificProductionAndNotify(ScientificProduction sp, Profile researcher)
        {
            try
            {
                InsertScientificProductionQuery(sp, researcher.Id);

                List<int> Ids = GetIDsOfResearchersInField(researcher.Id, researcher.Field);
                Notification notification = CreateNotification(sp, researcher);
                foreach (int id in Ids)
                {
                    Notify(notification, id);
                }

                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static Notification CreateNotification(ScientificProduction sp, Profile researcher)
        {
            Notification n = new Notification();
            n.username = researcher.Username;
            n.type = sp.Type;
            n.title = sp.Title;
            return n;
        }

        private void Notify(Notification notification, int researcherId)
        {
            if (Program.AuthenticationObj.Clients.TryGetValue(researcherId, out var researcher))
            {
                researcher.InformNewProduction(notification);
            }
        }

        private List<int> GetIDsOfResearchersInField(int publicherId, string field)
        {
            Microsoft.Data.Sqlite.SqliteCommand command = ConstructResearchersInFieldsCommand(publicherId, field);

            return ReadResearcherIDs(command);
        }

        private static List<int> ReadResearcherIDs(Microsoft.Data.Sqlite.SqliteCommand command)
        {
            List<int> Ids = new List<int>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ids.Add(reader.GetInt32(0));
                }
            }
            return Ids;
        }

        private Microsoft.Data.Sqlite.SqliteCommand ConstructResearchersInFieldsCommand(int publicherId, string field)
        {
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                select Id
                from employee
                where not employee.Id = $id and employee.Field = $field
            ";
            command.Parameters.AddWithValue("$id", publicherId);
            command.Parameters.AddWithValue("$field", field);
            return command;
        }

        private static void InsertScientificProductionQuery(ScientificProduction sp, int researcherId)
        {
            Microsoft.Data.Sqlite.SqliteCommand command = ConstructInsertCommand(sp, researcherId);

            command.ExecuteNonQuery();
        }

        private static Microsoft.Data.Sqlite.SqliteCommand ConstructInsertCommand(ScientificProduction sp, int researcherId)
        {
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                insert into scientific_productions (ResearcherId, Type, Title, Content)
                values ($researcherId, $type, $title, $content)
            ";
            command.Parameters.AddWithValue("$researcherId", researcherId);
            command.Parameters.AddWithValue("$type", sp.Type);
            command.Parameters.AddWithValue("$title", sp.Title);
            command.Parameters.AddWithValue("$content", sp.Content);
            return command;
        }
    }
}