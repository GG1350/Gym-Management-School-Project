using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using Microsoft.EntityFrameworkCore;
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
            .Include(m => m.Workouts)
                .ThenInclude(w => w.Exercises)
            .Include(m => m.Trainer)
            .FirstOrDefault(m => m.Id == id);

            if (member == null)
                throw new Exception("Member not found.");

            return member;
        }

        public IReadOnlyList<Members> GetAll()
        {
            return context.Members
            .Include(m => m.Workouts)
                .ThenInclude(w => w.Exercises)
            .Include(m => m.Trainer)
            .ToList();
        }

        public void Save(Members member)
        {
            if (member == null)
                throw new Exception("Member not found.");

            context.Members.Add(member);
            context.SaveChanges();
        }

        public void Update(int id, int tId, int wId, string action)
        {
            var db = context.Database;
            if (action == "book")
            {
                var member = context.Members
                    .Include(m => m.Workouts)
                    .ThenInclude (w => w.Exercises)
                    .Include(m => m.Trainer)
                    .FirstOrDefault(m => m.Id == id);

                var workout = context.Workouts
                    .FirstOrDefault(w => w.Id == wId);

                var trainer = context.Trainers
                    .FirstOrDefault(t => t.Id == tId);
                if (member != null && workout != null)
                {
                    workout.IsCompleted = true;
                    member.Trainer = trainer;
                    member.TranerId = trainer.Id;
                }
            }
            else if (action == "unbook")
            {
                var member = context.Members
                    .Include(m => m.Workouts)
                    .FirstOrDefault(m => m.Id == id);
                var workout = context.Workouts
                    .FirstOrDefault(w => w.Id == wId);
                if (member != null && workout != null)
                {
                    workout.IsCompleted = false;
                    member.Trainer = null;
                }
            }
            context.SaveChanges();
        }

        public void UpdateCard(MemberCard memberCard, int memberId)
        {
            var member = context.Members
                .FirstOrDefault(m => m.Id == memberId);
            if (member != null)
            {
                member.CardStatus = memberCard;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found.");
            }
        }

        public void UpdateSub(Subscribtion sub, int memberId)
        {
            var member = context.Members
                .FirstOrDefault(m => m.Id == memberId);
            if (member != null)
            {
                member.SubscribtionType = sub;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found.");
            }
        }
    }
}