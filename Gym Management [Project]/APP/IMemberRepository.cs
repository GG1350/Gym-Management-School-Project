using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.APP
{
    public interface IMemberRepository
    {
        Account GetById(int id);
        void Save(Account account);
        IReadOnlyList<Account> GetAll();
    }
}
