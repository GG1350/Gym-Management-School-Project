using Microsoft.EntityFrameworkCore;
using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.INFRASTRUCTURE.EFRepositories
{
    public class EFWorkoutRepository : IWorkoutRepository
    {
        private readonly GymDbContext context;

        public EFWorkoutRepository(GymDbContext context)
        {
            this.context = context;
        }

        public Workouts GetById(int id)
        {
            var workouts = context.Workouts.Include(w => w.Exercises)
                .FirstOrDefault(m => m.Id == id);

            if (workouts == null)
                throw new Exception("Workout not found.");

            return workouts;
        }

        public IReadOnlyList<Workouts> GetAll()
        {
            return context.Workouts.Include(w => w.Exercises)
                .ToList();
        }

        public void Save(Workouts workouts)
        {
            if (workouts == null)
                throw new ArgumentNullException(nameof(workouts));

            context.Workouts.Add(workouts);
            context.SaveChanges();
        }
        public void Update(Workouts workouts)
        {
            if (workouts == null)
                throw new ArgumentNullException(nameof(workouts));
            context.Workouts.Update(workouts);
            context.SaveChanges();
        }
    }
}
