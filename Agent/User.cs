using System.Collections.Generic;



namespace Agent
{
    public abstract class User
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string TeamId { get; set; }

        public Shared.Profile Profile { get; set; }
    }

    public class Employee : User
    {
        private Researcher researcher;
        private Manager manager;
    }

    public class Researcher
    {
        private string Field;
        private List<Shared.ScientificProduction> ScientificProductions;
    }

    public class Lead : Researcher
    {

    }

    public class Manager
    {

    }
}
