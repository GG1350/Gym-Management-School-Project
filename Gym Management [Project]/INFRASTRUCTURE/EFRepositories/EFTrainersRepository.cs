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
    public class EFTrainersRepository : ITrainersRepository
    {
        private readonly GymDbContext context;

        public EFTrainersRepository(GymDbContext context)
        {
            this.context = context;
        }

        public Trainers GetById(int id)
        {
            var trainers = context.Trainers
                .FirstOrDefault(m => m.Id == id);

            if (trainers == null)
                throw new Exception("Trainer not found.");

            return trainers;
        }
        public IReadOnlyList<Trainers> GetAll()
        {
            return context.Trainers
                .ToList();
        }

        public void Save(Trainers trainers)
        {
            if (trainers == null)
                throw new ArgumentNullException(nameof(trainers));

            context.Trainers.Add(trainers);
            context.SaveChanges();
        }

        public void Update(int id,int mId, string action)
        {
            var trainer = context.Trainers
                .FirstOrDefault(t => t.Id == id);
            if(action == "book")
            {
                trainer.IsAvailable = false;
                var member = context.Members.FirstOrDefault(m => m.Id == mId);
                trainer.Members.Add(member);
            }
            else if (action == "unbook")
            {
                trainer.IsAvailable = true;
                var member = context.Members.FirstOrDefault(m => m.Id == mId);
                trainer.Members.Remove(member);
            }
            context.SaveChanges();
        }
    }
}
