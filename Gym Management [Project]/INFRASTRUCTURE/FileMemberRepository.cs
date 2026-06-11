using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;

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
                    //bool found = true;
                    var newMembers = new Members(
                        db.NextId++,
                        Members.FirstName,
                        Members.LastName,
                        Members.Workouts.ToList(),
                        Members.SubscribtionType
                        );
                    db.Members.Add(newMembers);
            }
            else
            {
                bool found = false;
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
        public void Update(int id, int tId, int wId, string action)
        {
            var db = storage.Load();
            if (action == "book")
            {
                db.Members.FirstOrDefault(m => m.Id == id).progress.Add(db.Members.FirstOrDefault(m => m.Id == id).Workouts.ToList()[wId]);
                db.Members.FirstOrDefault(m => m.Id == id).Trainer = db.Trainers.FirstOrDefault(t => t.Id == tId);
            }
            else if (action == "unbook")
            {
                db.Members.FirstOrDefault(m => m.Id == id).progress.Remove(db.Members.FirstOrDefault(m => m.Id == id).Workouts.ToList()[wId]);
                db.Members.FirstOrDefault(m => m.Id == id).Trainer = null;
            }
            storage.Save(db);
        }
        public void UpdateCard(MemberCard memberCard, int memberId)
        {
            var db = storage.Load();
            var member = db.Members.FirstOrDefault(m => m.Id == memberId);
            if (member != null)
            {
                member.CardStatus = memberCard;
            }
            storage.Save(db);
        }
        public void UpdateSub(Subscribtion sub, int memberId)
        {
            var db = storage.Load();
            var member = db.Members.FirstOrDefault(m=>m.Id == memberId);
            if(member != null)
            {
                member.SubscribtionType = sub;
            }
            storage.Save(db);
        }
    }
}
