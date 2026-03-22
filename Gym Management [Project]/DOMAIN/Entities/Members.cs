using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.DOMAIN.Enum;

namespace Gym_Management__Project_.DOMAIN.Entities
{
    public class Members
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Workouts> Workouts { get; set; } = new List<Workouts>();
        public MemberCard CardStatus { get; set; }
        public Subscribtion SubscribtionType { get; set; }
        public bool HasTrainer => SubscribtionType == Subscribtion.MonthTrainer || SubscribtionType == Subscribtion.TrimesterTrainer || SubscribtionType == Subscribtion.YearTrainer;

        //For member with a trainer
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

        //For member without a trainer
        public Members(int id, string firstName, string lastName, Subscribtion subscribtionType)
        {
            if (id < 0) throw new ArgumentException("Id must be at least 0");
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("A first name is required");
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("A last name is required");
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CardStatus = MemberCard.Active;
            SubscribtionType = subscribtionType;
        }

        public void AddWorkout(Workouts workout)
        {
            if (workout == null) throw new ArgumentNullException("The given information is not correct");
            try
            {
                Workouts.Add(workout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the workout: {ex.Message}");
            }
        }
    }
}