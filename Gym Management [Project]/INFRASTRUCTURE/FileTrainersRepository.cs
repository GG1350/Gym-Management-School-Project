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

        public void Save(Trainers trainer)
        {
            var db = storage.Load();

            if (trainer.Id == 0)
            {
                //bool found = true;
                var newTrainers = new Trainers(
                    db.NextId++,
                    trainer.FirstName,
                    trainer.LastName,
                    trainer.Members.ToList()
                    );
                db.Trainers.Add(newTrainers);
            }
            else
            {
                bool isFound = true;

                for (int i = 0; i < db.Trainers.Count; i++)
                {
                    if (db.Trainers[i].Id == trainer.Id)
                    {
                        db.Trainers[i] = trainer;
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

        public Trainers GetById(int id)
        {
            var db = storage.Load();

            foreach (var Trainers in db.Trainers)
            {
                if (Trainers.Id == id)
                {
                    return Trainers;
                }
            }

            throw new Exception($"Trainers with Id {id} not found");

        }
        public void Update(int id, int wId,int mId)
        {
            var db = storage.Load();
            //db.Trainers[id].Schedule.Add(db.Members[mId].MemberWorkouts[wId]); HAS TO BE FIXED
            storage.Save(db);
        }
    } 
}
