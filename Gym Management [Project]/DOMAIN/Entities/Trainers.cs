using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gym_Management__Project_.DOMAIN.Entities
{
    public class Trainers
    {
        public int Id   { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        //public List<Members> members { get; set; } = new List<Members>();
        //public List<Workouts> Schedule { get { return new List<Workouts>(); } set { if (Schedule.Count > 3) IsAvailable = false; throw new Exception("The trainer is too busy for the day"); } }
        public ICollection<Members> Members { get; private set; }
        = new List<Members>();

        public Trainers() { }

        public Trainers(int id, string firstName, string lastName, List<Members> members)
        {
            if (id < 0) { throw new ArgumentException("Id must be at least 0"); }
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("First name is required");
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("Last name is required");

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Members = members;
        }
    }
}
