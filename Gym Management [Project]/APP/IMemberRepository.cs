using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.DOMAIN.Entities;

namespace Gym_Management__Project_.APP
{
    public interface IMemberRepository
    {
        Members GetById(int id);
        void Save(Members members);
        IReadOnlyList<Members> GetAll();
    }
}
