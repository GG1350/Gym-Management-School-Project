using Gym_Management__Project_.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.APP
{
    public interface IWorkoutRepository
    {
        Workouts GetById(int id);
        void Save(Workouts Workouts);
        IReadOnlyList<Workouts> GetAll();
    }
}
