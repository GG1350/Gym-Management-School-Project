using Gym_Management__Project_.DOMAIN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.DOMAIN.Entities
{
    public class Workouts
    {
        public int Id { get; set; }
        public int MemberId {  get; set; }
        public Members Member { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; } = false;
        public ICollection<Exercises> Exercises { get; set; } = new List<Exercises>();

        public Workouts() { }
        public Workouts(int id,int memberId,string name, List<Exercises> exercises)
        {
            Id = id;
            MemberId = memberId;
            Name = name;
            Exercises = exercises;
        }
    }
}