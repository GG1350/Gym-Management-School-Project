using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;

namespace Gym_Management__Project_.INFRASTRUCTURE
{
    public class FileMemberRepository : IMemberRepository
    {
        private readonly FileStorage storage;

        public FileMemberRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Members> GetAll()
        {
            var db = storage.Load();
            return db.Members;
        }

        public void Save(Members Members)
        {
            var db = storage.Load();

            if (Members.Id == 0)
            {
                if (Members.HasTrainer == true)
                {
                    bool found = true;
                    var newMembers = new Members(
                        db.NextId++,
                        Members.FirstName,
                        Members.LastName,
                        Members.Workouts,
                        Members.SubscribtionType
                        );
                    db.Members.Add(newMembers);
                }
                else
                {
                    bool found = true;
                    var newMembers = new Members(
                        db.NextId++,
                        Members.FirstName,
                        Members.LastName,
                        Members.SubscribtionType
                        );
                    db.Members.Add(newMembers);
                }
            }
            else
            {
                bool found = true;
                for (int i = 0; i < db.Members.Count; i++)
                {
                    if (db.Members[i].Id == Members.Id)
                    {
                        db.Members[i] = Members;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new Exception("Member not found");
                }
            }

            storage.Save(db);

        }

        public Members GetById(int id)
        {
            var db = storage.Load();

            foreach (var Members in db.Members)
            {
                if (Members.Id == id)
                {
                    return Members;
                }
            }

            throw new Exception($"Members with Id {id} not found");

        }
    }
}
