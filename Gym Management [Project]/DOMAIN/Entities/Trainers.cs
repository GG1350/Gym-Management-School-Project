using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.DOMAIN.Entities
{
    public class Trainers
    {
        public int Id   { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Members> Members { get; set; } = new List<Members> ();

        public Trainers(int id, string firstName, string lastName, List<Members> members)
        {
            if(id<0) {throw new ArgumentException("Id must be at least 0");}
            if(string.IsNullOrEmpty(firstName)) {throw new ArgumentException("First name is required"); }
            if(string.IsNullOrEmpty(lastName)) {throw new ArgumentException("Last name is required"); }

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Members = members;
        }
    }
}
