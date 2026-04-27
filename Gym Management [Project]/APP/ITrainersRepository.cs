using Gym_Management__Project_.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.APP
{
    public interface ITrainersRepository
    {
        Trainers GetById(int id);
        void Save(Trainers trainers);
        IReadOnlyList<Trainers> GetAll();
    }
}
