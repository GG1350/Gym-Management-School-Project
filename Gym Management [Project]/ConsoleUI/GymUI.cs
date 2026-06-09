using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gym_Management__Project_.ConsoleUI
{
    public class GymUI
    {
        private readonly GymService gymService;
        public GymUI(GymService gymService)
        {
            this.gymService = gymService;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                UI();

                Console.Write("Choose: ");
                string input = Console.ReadLine();
                string Winput;//workoutUI
                switch (input)
                {
                    case "1":
                        BookTraining();
                        break;
                    case "2":
                        Winput = Console.ReadLine();
                        switch (Winput)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                        }
                        break;
                    case "3":
                        AddMember();
                        break;
                    case "4":
                        ShowMembers();
                        break;
                    case "5":
                        CreateWorkout();
                        break;
                    case "x":
                        running = false;
                        break;
                }
            }
        }

        public static void UI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("      ==== GYM SYSTEM ====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[1] "); Console.ResetColor(); Console.WriteLine("Create MEMBER account");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[2] "); Console.ResetColor(); Console.WriteLine("Show plan");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[3] "); Console.ResetColor(); Console.WriteLine("Actions with Trainers");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[4] "); Console.ResetColor(); Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[5] "); Console.ResetColor(); Console.WriteLine("CreateWorkout");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
        }

        private void AddTrainer() 
        {
            Console.WriteLine("First name: ");
            string FName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            string LName = Console.ReadLine();
            List<Members> members = new List<Members>();
            gymService.CreateTrainer(FName, LName, members);
        }

        private void ShowTrainers()
        {
            var trainers = gymService.GetTrainers();
            foreach (var t in trainers)
            {
                string availability = t.IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"{t.Id} {t.FirstName} {t.LastName} {availability}"); 
            }
            Pause();
        }

        private void AddMember()
        {
            Console.WriteLine("First name: ");
            string FName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            string LName = Console.ReadLine();
            Console.WriteLine("What type of subscription do you want by id: ");
            foreach (Subscribtion s in Enum.GetValues(typeof(Subscribtion)))
            {
                Console.WriteLine($"{(int)s} - {s}");
            }
            var id = int.Parse(Console.ReadLine());
            if (!Enum.IsDefined(typeof(Subscribtion), id))
            {
                Console.WriteLine("Wrong id!");
                return;
            }
            var subscribtion = (Subscribtion)id;
            List<Workouts> workouts = new List<Workouts>();
            gymService.CreateMember( FName, LName, workouts, subscribtion);
            Pause();
        }

        private void ShowMembers()
        {
            var members = gymService.GetMembers();
            foreach (var m in members) Console.WriteLine($"{m.Id} {m.FirstName} {m.LastName}");
        }
        private void CreateWorkout() //kosyo
        {
            Console.WriteLine("What exercises do you want to add in the workout?");
            Pause();
        }

        private void EditWorkout()//kosyo
        {
            var workouts = gymService.GetWorkouts();
            foreach (var w in workouts) Console.WriteLine($"What changes you want in the workout {w.Id}:");
            Pause();
        }

        private void ShowWorkout() { }//kosyo; needs to show the workout by a specified id and the exercises in it. Overalps with the show exercises

        private Exercises AddExercise()//this will be used with the creation and editing of the workout
        {
            Console.WriteLine("What exercise do you want to add in the workout?");
            string name = Console.ReadLine();
            Console.Write("How much do you weigh (in kg)? ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("How long will the exercise last (in minutes)?");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("How heavy will the exercise be (for example running at a low pace is equal 3.5 and fast  pace running could be 10 or higher)");
            double met = double.Parse(Console.ReadLine());//check Exercises.cs for more info about MET
            Pause();
            return new Exercises(name, duration, met, weight);
        }

        private void BookTraining()
        {
            Console.WriteLine("Who wants to book a training(write the id)?");
            ShowMembers();
            var members = gymService.GetMembers();
            Console.Write("Write your choice: ");
            int memberId = int.Parse(Console.ReadLine());
            if (memberId == 0||memberId>members.Count) throw new Exception("Invalid member id!");

            Console.WriteLine("Which available trainer is to be booked(write the id)?");
            var trainers = gymService.GetTrainers();
            foreach (var t in trainers)
            {
                if (t.IsAvailable) Console.WriteLine($"{t.Id} {t.FirstName} {t.LastName}");
            }
            Console.Write("Write your choice: ");
            int trainerId = int.Parse(Console.ReadLine());
            if(trainerId ==0||trainerId>trainers.Count) throw new Exception("Invalid trainer id!");
            Console.WriteLine("Which of your workouts do you want to book(write the Id): ");
            if (members[memberId].Workouts.Count < 1) throw new Exception("You have no workout created!");
            foreach(var w in members[memberId].Workouts)
            {
                Console.WriteLine(w.Id + w.Name + "\nExercises:" + w.Exercises);
            }
            Console.Write("Write your choice: ");
            int workoutId = int.Parse(Console.ReadLine());
            if (workoutId == 0 || workoutId > members[memberId].Workouts.Count) throw new Exception("Invalid workout id");
            //actual booking
            gymService.BookTraining(memberId, workoutId, trainerId, "book");

            //adding the progress
            members[memberId].progress.Add(members[memberId].Workouts.ToList()[workoutId]);
            members[memberId].GetTotalCalories();
            Pause();
        }

        private void UnbookTraining() //TO DO; kosyo
        {
            Console.WriteLine("Who wants to unbook a training (write the id)?");
            ShowMembers();

            var members = gymService.GetMembers();

            Console.Write("Write your choice: ");
            int memberId = int.Parse(Console.ReadLine());

            if (memberId == 0 || memberId > members.Count)
                throw new Exception("Invalid member id!");

            Console.WriteLine("Which trainer do you want to unbook from (write the id)?");
            ShowTrainers();

            var trainers = gymService.GetTrainers();

            Console.Write("Write your choice: ");
            int trainerId = int.Parse(Console.ReadLine());

            if (trainerId == 0 || trainerId > trainers.Count)
                throw new Exception("Invalid trainer id!");

            Console.WriteLine("Which workout do you want to remove (write the id)?");

            var workouts = gymService.GetWorkouts();

            foreach (var workout in workouts)
            {
                Console.WriteLine(workout);
            }

            Console.Write("Write your choice: ");
            int workoutId = int.Parse(Console.ReadLine());

            if (workoutId == 0 || workoutId > workouts.Count)
                throw new Exception("Invalid workout id!");

            gymService.BookTraining(memberId, workoutId, trainerId, "unbook");

            Console.WriteLine("Training unbooked successfully!");
            Pause();

        }
        private void CheckProgress() //calories; visits; kosyo
        {
            Console.WriteLine("Choose member:");
            ShowMembers();

            int id = int.Parse(Console.ReadLine());

            var member = gymService.GetMemberById(id);

            Console.Write("Enter body weight (kg): ");
            double bodyWeight = double.Parse(Console.ReadLine());

            double totalCalories = 0;

            foreach (var workout in member.progress)
            {
                foreach (var exercise in workout.Exercises)
                {
                    totalCalories += exercise.CalculateCalories(bodyWeight);
                }
            }

            Console.WriteLine($"Completed workouts: {member.progress.Count}");
            Console.WriteLine($"Calories burnt: {totalCalories:F2}");

            Pause();
        }
        private void CheckTrainer()//availability and members; kosyo
        {
            ShowTrainers();

            Console.Write("Trainer Id: ");
            int id = int.Parse(Console.ReadLine());

            var trainer = gymService.GetTrainer(id);
        }

        private void ManageTrainerTimetable() //maybe should happen with unbook training
        {
        
        }

        private void CheckGymBusyness() //get the availability of each trainer; kosyo
        {
        
        }

        private void CheckMostUsedExercises() 
        {
        
        }

        private void ManageMemberCards() 
        {
            Console.WriteLine("Choose member:");
            ShowMembers();

            int id = int.Parse(Console.ReadLine());

            gymService.ChangeCardStatus(id);

            Console.WriteLine("Card status changed!");
            Pause();
        }

        private void GetTrainingHistory() //the member's progress; kosyo
        {
        
        }

        private void CheckActiveMembers() //members with active subscription; kosyo
        {
            var members = gymService.GetMembers();

            foreach (var member in members)
            {
                if (member.CardStatus == MemberCard.Active)
                {
                    Console.WriteLine(member);
                }
            }

            Pause();
        }
        private void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }
    }
}


