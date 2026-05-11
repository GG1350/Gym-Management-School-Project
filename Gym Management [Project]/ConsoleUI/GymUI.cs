using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
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
                        RegistrateMemberAccount();
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

        private void RegistrateMemberAccount()
        {
            //Console.Write("Name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Type:");
            //Console.WriteLine("Cash: 0");
            //Console.WriteLine("Bank: 1");
            //Console.WriteLine("DebitCard: 2");
            //Console.WriteLine("VirtualCard: 3");
            //Console.WriteLine("SavingBank: 4");
            //Console.Write("Choos type: ");
            //int type = int.Parse(Console.ReadLine());
            //var typeAccount = (AccountType)type;
            //Console.Write("Initial amount: ");
            //decimal amount = decimal.Parse(Console.ReadLine());
            //try
            //{
            //    gymService.CreateAccount(name, typeAccount, amount);
            //    Console.WriteLine("New account created!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.ReadLine();
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

        private void ShowTrainers()//TO TUNE: to show more info
        {
            var trainers = gymService.GetTrainers();
            foreach(var t in trainers) Console.WriteLine($"{t.FirstName} {t.LastName}");
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
        }

        private void ShowMembers()//TO TUNE: to show more info
        {
            var members = gymService.GetMembers();
            foreach (var m in members) Console.WriteLine($"{m.FirstName} {m.LastName}");
            Console.ReadLine();
        }
        private void CreateWorkout() 
        {
            Console.WriteLine("What exercises do you want to add in the workout?");
        }

        private void EditWorkout()
        {
            var workouts = gymService.GetWorkouts();
            foreach (var w in workouts) Console.WriteLine($"What changes you want in the workout {w.Id}:");
            Console.ReadLine();
        }

        private void CheckProgress() { }//calories; visits;

        private void BookTraining() { }

        private void UnbookTraining() { }

        private void CheckTrainer() { }

        private void ManageTrainerTimetable() { }

        private void CheckGymBusyness() { }

        private void CheckTypesOfTrainings() { }

        private void CheckMostUsedExercises() { }

        private void ManageMemeberCards() { }

        private void TrainingHistory() { }

        private void CheckActiveMembers() { }
    }
}


