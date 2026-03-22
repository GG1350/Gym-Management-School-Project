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

        public FileAccountRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Account> GetAll()
        {
            var db = storage.Load();
            return db.Accounts;
        }

        public void Save(Account account)
        {
            var db = storage.Load();

            if (account.Id == 0)
            {
                var newAccount = new Account(
                    //int id, string name, AccountType type, Money balance
                    db.NextId++,
                    account.Name,
                    account.Type,
                    account.Balance
                    );
                db.Accounts.Add(newAccount);
            }
            else
            {
                bool found = false;
                for (int i = 0; i < db.Accounts.Count; i++)
                {
                    if (db.Accounts[i].Id == account.Id)
                    {
                        db.Accounts[i] = account;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new Exception("Account not found");
                }
            }

            storage.Save(db);

        }
    }
}
