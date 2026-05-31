using Gym_Management__Project_.DOMAIN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gym_Management__Project_.DOMAIN.Entities
{
    public class Members
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? TranerId { get; set; }//could be null because not all members have a trainer
        public Trainers Trainer { get; set; }
        //public Trainers Trainers { get; set; } = null;//SHOULD BE NULL!  !!!!!!!!!!!!!!!!!!
        //public List<Workouts> MemberWorkouts { get; set; } = new List<Workouts>();
        public MemberCard CardStatus { get; set; }
        public Subscribtion SubscribtionType { get; set; }
        public bool HasTrainer => SubscribtionType == Subscribtion.MonthTrainer || SubscribtionType == Subscribtion.TrimesterTrainer || SubscribtionType == Subscribtion.YearTrainer;
        //public List<Workouts> progress = new List<Workouts>();
        public ICollection<Workouts> Workouts { get; private set; }
        = new List<Workouts>();
        
        public Members() { }
        public Members(int id, string firstName, string lastName, List<Workouts> workouts, Subscribtion subscribtionType)
        {
            if (id < 0) throw new ArgumentException("Id must be at least 0");
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("A first name is required");
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("A last name is required");

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Workouts = workouts;
            CardStatus = MemberCard.Active;
            SubscribtionType = subscribtionType;
        }
    }
}