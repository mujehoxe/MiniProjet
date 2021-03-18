using Shared;
using System;

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

        public string PublishScientificProduction(ScientificProduction S, int researcherId)
        {
            var command = Program.SqlConn.CreateCommand();
            command.CommandText = @"
                insert into scientific_productions (ResearcherId, Type, Title, Content)
                values ($researcherId, $type, $title, $content)
            ";
            command.Parameters.AddWithValue("$researcherId", researcherId);
            command.Parameters.AddWithValue("$type", S.Type);
            command.Parameters.AddWithValue("$title", S.Title);
            command.Parameters.AddWithValue("$content", S.Content);

            try
            {
                command.ExecuteNonQuery();
                return "done";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}