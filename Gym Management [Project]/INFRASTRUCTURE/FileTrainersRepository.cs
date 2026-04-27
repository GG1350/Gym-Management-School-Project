using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.INFRASTRUCTURE
{
    public class FileTrainersRepository : ITrainersRepository
    {
        private readonly FileStorage storage;

        public FileTrainersRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Trainers> GetAll()
        {
            var db = storage.Load();
            return db.Trainers;
        }

        public void Save(Trainers Trainers)
        {
            var db = storage.Load();

            if (Trainers.Id == 0)
            {
                bool found = true;
                var newTrainers = new Trainers(
                    db.NextId++,
                    Trainers.FirstName,
                    Trainers.LastName,
                    Trainers.Members
                    );
                db.Trainers.Add(newTrainers);
            }
            else
            {
                bool isFound = true;

                for (int i = 0; i < db.Trainers.Count; i++)
                {
                    if (db.Trainers[i].Id == Trainers.Id)
                    {
                        db.Trainers[i] = Trainers;
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
