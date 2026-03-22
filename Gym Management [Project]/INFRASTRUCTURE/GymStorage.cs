using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.DOMAIN.Entities;

namespace Gym_Management__Project_.INFRASTRUCTURE
{
    public class GymStorage
    {
        public int NextId { get; set; } = 1;
        public List<Trainers> Trainers { get; set; } = new List<Trainers>(); 

        public List<Members> Members { get; set; } = new List<Members>();

        public List<Workouts> Workouts { get; set; } = new List<Workouts>();
    }
}