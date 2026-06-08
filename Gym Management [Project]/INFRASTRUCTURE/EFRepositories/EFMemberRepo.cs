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
    public class EfMemberRepository : IMemberRepository
    {
        private readonly GymDbContext context;

        public EfMemberRepository(GymDbContext context)
        {
            this.context = context;
        }

        public Members GetById(int id)
        {
            var member = context.Members
                .FirstOrDefault(m => m.Id == id);

            if (member == null)
                throw new Exception("Member not found.");

            return member;
        }

        public IReadOnlyList<Members> GetAll()
        {
            return context.Members
                .ToList();
        }

        public void Save(Members member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            context.Members.Add(member);
            context.SaveChanges();
        }

        public void Update(int id, int wId, string action)
        {
            //context.Members.Update(member); ДА СЕ ОПРАВИ
            //context.SaveChanges();
        }
    }
}
