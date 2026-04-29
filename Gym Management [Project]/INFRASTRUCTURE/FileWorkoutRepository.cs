using Gym_Management__Project_.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.APP;

namespace Gym_Management__Project_.INFRASTRUCTURE
{
    public class FileWorkoutRepository : IWorkoutRepository
    {
        private readonly FileStorage storage;

        public FileWorkoutRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Workouts> GetAll()
        {
            var db = storage.Load();
            return db.Workouts;
        }

        public void Save(Workouts Workouts)
        {
            var db = storage.Load();

            if (Workouts.Id == 0)
            {
                bool found = true;
                var newWorkouts = new Workouts(
                    db.NextId++,
                    Workouts.Type,
                    Workouts.Exercises
                    );
                db.Workouts.Add(newWorkouts);
            }
            else
            {
                bool isFound = true;

                for (int i = 0; i < db.Workouts.Count; i++)
                {
                    if (db.Workouts[i].Id == Workouts.Id)
                    {
                        db.Workouts[i] = Workouts;
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    throw new Exception("Trainer not found");
                }
            }

            storage.Save(db);
        }
    }
}
