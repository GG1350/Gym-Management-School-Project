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
                //.Include(m => m.Workouts)
                .FirstOrDefault(m => m.Id == id);

            if (trainers == null)
                throw new Exception("Trainer not found.");

            return trainers;
        }

    }
}
