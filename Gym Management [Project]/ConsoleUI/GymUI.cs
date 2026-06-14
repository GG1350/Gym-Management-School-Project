using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
namespace Gym_Management__Project_.ConsoleUI
{
    public class GymUI
    {
        private readonly GymService gymService;
        public GymUI(GymService service)
        {
            this.gymService = service;
        }
        // number validation:             if (!int.TryParse(input, out int number)) { Console.WriteLine("Invalid Input"); Pause(); return; }
        // string validation:             if (int.TryParse(input, out int number)||string.IsNullOrWhiteSpace(input)) { Console.WriteLine("Invalid Input"); Pause(); return; }
        public void Run()//Done
        {
            bool running = true;

            while (running)
            {
                UI();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Choose: ");
                Console.ResetColor();
                string input;//workoutUI
                input = Console.ReadLine();
                if (int.TryParse(input, out int number)||input=="x")
                {
                    switch (input)
                    {
                        case "1":
                            MemberUI();
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    AddMember();
                                    break;
                                case "2":
                                    BookTraining();
                                    break;
                                case "3":
                                    UnbookTraining();
                                    break;
                                case "4":
                                    ShowMembers();
                                    break;
                                case "5":
                                    CheckProgress();
                                    break;
                                case "x":
                                    break;
                            }
                            break;
                        case "2":
                            TrainerUI();
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    AddTrainer();
                                    break;
                                case "2":
                                    ManageTrainerTimetable();
                                    break;
                                case "3":
                                    CheckTrainer();
                                    break;
                                case "4":
                                    ShowTrainers();
                                    break;
                                case "5":
                                    GetTrainingHistory();
                                    break;
                                case "6":
                                    CheckActiveMembers();
                                    break;
                                case "x":
                                    break;
                            }
                            break;
                        case "3":
                            SubscribtionUI();
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    ManageMemberCards();
                                    break;
                                case "2":
                                    ManageSubsription();
                                    break;
                                case "x":
                                    break;
                            }
                            break;
                        case "4":
                            WorkoutUI();
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    CreateWorkout();
                                    break;
                                case "2":
                                    EditWorkout();
                                    break;
                                case "3":
                                    ShowWorkout();
                                    break;
                                case "x":
                                    break;
                            }
                            break;
                        case "5":
                            CheckGymBusyness();
                            break;
                        case "6":
                            CheckMostUsedExercises();
                            break;
                        case "x":
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Pause();
                }
            }
        }
        public static void UI()//Done
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("    ==== GYM MANAGEMENT ====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Member management");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Trainer management");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [3] "); Console.ResetColor(); Console.WriteLine("Subscription management");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [4] "); Console.ResetColor(); Console.WriteLine("Workout management");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [5] "); Console.ResetColor(); Console.WriteLine("Gym busyness");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [6] "); Console.ResetColor(); Console.WriteLine("Most common exercise");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  [X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
        }

        //member UI

        public static void MemberUI()//Done
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+===============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("   ==== MEMBER MANAGEMENT ====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+===============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Create a member account");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Book a workout");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [3] "); Console.ResetColor(); Console.WriteLine("Unbook a workout");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [4] "); Console.ResetColor(); Console.WriteLine("Show all members");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [5] "); Console.ResetColor(); Console.WriteLine("Check your progress");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  [X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
        }
        public void AddMember()//Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("First name: ");
            Console.ResetColor();
            string Finput = Console.ReadLine();
            if (int.TryParse(Finput, out int Fnumber) || string.IsNullOrWhiteSpace(Finput)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            string FName = Finput;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Last name: ");
            Console.ResetColor();
            string Linput = Console.ReadLine();
            if (int.TryParse(Linput, out int Lnumber) || string.IsNullOrWhiteSpace(Linput)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            string LName = Linput;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the ID of the subscription plan you want");
            Console.ResetColor();
            foreach (Subscribtion s in Enum.GetValues(typeof(Subscribtion)))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{(int)s}] - "); Console.ResetColor(); Console.WriteLine($"{s}");
            }
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            if (!Enum.IsDefined(typeof(Subscribtion), id))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Wrong id!");
                Console.ResetColor();
                return;
            }
            var subscribtion = (Subscribtion)id;
            List<Workouts> workouts = new List<Workouts>();
            gymService.CreateMember(FName, LName, workouts, subscribtion);
            Pause();
        }
        public void BookTraining()//Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            var members = gymService.GetMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("There are no member created");
                Pause();
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out int memberId)) { Console.WriteLine("Invalid Input"); Pause(); return; }

            if (gymService.GetMemberById(memberId).SubscribtionType == Subscribtion.Month ||
                gymService.GetMemberById(memberId).SubscribtionType == Subscribtion.Trimester ||
                gymService.GetMemberById(memberId).SubscribtionType == Subscribtion.Year)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Your subsription does not allow you to use a trainer!");
                Console.ResetColor();
                Pause();
                return;
            }

            if(gymService.GetMemberById(memberId).TranerId !=null)
            {
                Console.WriteLine("You already have a booked workout!");
                Pause();
                return;
            }

            if (memberId < 0 || members.Max(m=>m.Id)+1 <memberId)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid member ID!");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the ID of the trainer you want");
            Console.ResetColor();
            var trainers = gymService.GetTrainers(); 
            if (trainers.Count == 0)
            {
                Console.WriteLine("There are no trainers created");
                Pause();
                return;
            }
            foreach (var t in trainers)
            {
                if (t.IsAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"[{t.Id}] "); Console.ResetColor();
                    Console.WriteLine($"{t.FirstName} {t.LastName}");
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Write your choice: ");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int trainerId)) { Console.WriteLine("Invalid Input"); Pause(); return; }

            if (trainerId == 0 || trainerId > trainers.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid trainer id!");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the workout ID you want to book");
            Console.ResetColor();
            if (gymService.GetMemberById(memberId).Workouts.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You have no workouts created!");
                Console.ResetColor();
                Pause();
                return;
            }
            foreach (var w in gymService.GetMemberById(memberId).Workouts)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{w.Id}] ");
                Console.ResetColor();
                Console.WriteLine(w.Name);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("     Exercises:");
                foreach(var e in w.Exercises)
                {
                    Console.WriteLine($"        -{e.Name}");
                }
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Write your choice: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int workoutId)) { Console.WriteLine("Invalid Input"); Pause(); return; }

            if (workoutId == 0 || workoutId > gymService.GetMemberById(memberId).Workouts.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid workout id");
                Console.ResetColor();
                Pause();
                return;
            }
            //actual booking
            gymService.BookTraining(memberId, workoutId, trainerId, "book");

            gymService.GetMemberById(memberId).GetTotalCalories();
            Pause();
        }
        public void UnbookTraining() //Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            var members = gymService.GetMembers();
            if (members.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("There are no member created");
                Console.ResetColor();
                Pause();
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out int memberId)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            if (memberId < 0 || memberId > members.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid member id!");
                Console.ResetColor();
                Pause();
                return;
            }
            if (gymService.GetMemberById(memberId).Trainer == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("This member has no trainer booked!");
                Console.ResetColor();
                Pause();
                return;
            }

            var trainers = gymService.GetTrainers();
            if (trainers.Count == 0)
            {
                Console.WriteLine("There are no trainers created");
                Pause();
                return;
            }
            int trainerId = 0;
            int workoutId = gymService.GetMemberById(memberId).Progress.ToList()[gymService.GetMemberById(memberId).Progress.Count() - 1].Id;
            foreach (var t in trainers)
            {
                if (t.Members.Contains(gymService.GetMemberById(memberId)))
                {
                    trainerId = t.Id;
                }
            }

            gymService.BookTraining(memberId, workoutId, trainerId, "unbook");
            Pause();
        }
        public void ShowMembers()//Done
        {
            var members = gymService.GetMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("There are no member created");
                Pause();
                return;
            }
            foreach (var m in members)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{m.Id}] "); Console.ResetColor(); Console.WriteLine($"{m.FirstName} {m.LastName}");
            }
            Pause();
            return;
        }
        public void CheckProgress() //calories; visits; Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid Input"); Pause(); return; }

            var member = gymService.GetMemberById(id);

            member.GetTotalCalories();

            Console.Write($"Completed workouts: "); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"[{member.Progress.Count()}]");
            Console.ResetColor();
            Console.Write($"Calories burnt: "); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"[{member.TotalCaloriesBurnt}]");
            Console.ResetColor();

            Pause();
            return;
        }

        //trainer UI

        public static void TrainerUI()//Done
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  ==== TRAINER MANAGEMENT ====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Create a trainer account");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Manage trainer timetable");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [3] "); Console.ResetColor(); Console.WriteLine("Check trainer");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [4] "); Console.ResetColor(); Console.WriteLine("Show all trainers");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [5] "); Console.ResetColor(); Console.WriteLine("Get training history");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [6] "); Console.ResetColor(); Console.WriteLine("Check active members");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  [X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
        }
        public void AddTrainer()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("First name: ");
            Console.ResetColor();
            string input = Console.ReadLine();
            if (int.TryParse(input, out int Fnumber) || string.IsNullOrWhiteSpace(input)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            string FName = input;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Last name: ");
            Console.ResetColor();
            string Linput = Console.ReadLine();
            if (int.TryParse(input, out int Lnumber) || string.IsNullOrWhiteSpace(input)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            string LName = Linput;
            List<Members> members = new List<Members>();
            gymService.CreateTrainer(FName, LName, members);
        }//Done
        public void ShowTrainers()
        {
            var trainers = gymService.GetTrainers();
            if (trainers.Count == 0)
            {
                Console.WriteLine("There are no trainers created");
                Pause();
                return;
            }
            foreach (var t in trainers)
            {
                string availability = t.IsAvailable ? "Available" : "Not Available";
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{t.Id}] "); Console.ResetColor(); Console.WriteLine($"{t.FirstName} {t.LastName} - {availability}");
            }
            Pause();
        }//Done
        public void CheckTrainer()//availability and members; Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter trainer ID");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid Input"); Pause(); return; }

            var trainer = gymService.GetTrainerById(id);
            if(trainer == null)
            {
                Console.WriteLine("There is no trainer with this id");
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"Name: "); Console.ResetColor(); Console.WriteLine($"{trainer.FirstName} {trainer.LastName}"); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"Available: "); Console.ResetColor(); Console.WriteLine($"{(trainer.IsAvailable ? "Yes" : "No")}");

            if (trainer.Members.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No assigned members!");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Members:");
            Console.ResetColor();
            foreach (var member in trainer.Members)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{member.Id}]"); Console.ResetColor(); Console.WriteLine($"{member.FirstName} {member.LastName}");
            }
            Pause();
            return;
        }
        public void ManageTrainerTimetable() //maybe should happen with unbook training; Done
        {
            var members = gymService.GetMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("There are no member created");
                Pause();
                return;
            }
            var trainers = gymService.GetTrainers();
            if (trainers.Count == 0)
            {
                Console.WriteLine("There are no trainers created");
                Pause();
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter the trainer ID whom's timetable you want to change: ");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int tChoice)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("   == What do you want to do ==");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Unbook training");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+================================+");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int choice)||choice>3||choice<1) { Console.WriteLine("Invalid Input"); Pause(); return; }
            switch (choice)
            {
                case 1:
                    foreach (var m in members)
                    {
                        if (m.TranerId==gymService.GetTrainerById(tChoice).Id)
                        {
                            gymService.BookTraining(m.Id, m.Progress.Count(), tChoice, "unbook");
                        }
                    }
                    break;
            }
        }
        public void GetTrainingHistory() //the member's progress; Done
        {
            var members = gymService.GetMembers();
            if (members.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("There are no member created");
                Console.ResetColor();
                Pause();
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter member ID");
            Console.ResetColor();
            foreach (var m in members)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{m.Id}] "); Console.ResetColor(); Console.WriteLine($"{m.FirstName} {m.LastName}");
            }
            if (!int.TryParse(Console.ReadLine(), out int id)||id<0||id>members.Count+1) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid Input"); Console.ResetColor();  Pause(); return; }
            var member = gymService.GetMemberById(id);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"Training history for "); Console.ResetColor(); Console.WriteLine($"{member.FirstName} {member.LastName}:");
            foreach (var workout in member.Progress)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{workout.Id}]"); Console.ResetColor(); Console.WriteLine($"| Name: {workout.Name}");
            }
            Pause();
        }
        public void CheckActiveMembers() //members with active subscription; Done
        {
            var members = gymService.GetMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("There are no member created");
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Active members:");
            Console.ResetColor();

            foreach (var member in members)
            {
                if (member.CardStatus == MemberCard.Active)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"[{member.Id}] "); Console.ResetColor(); Console.WriteLine($"{member.FirstName} {member.LastName}");
                }
            }

            Pause();
        }

        //Subs UI

        public static void SubscribtionUI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+===================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  ==== SUBSCRIPTION MANAGEMENT ====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+===================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Manage card plan");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Manage subscription plan");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  [X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+===================================+");
            Console.ResetColor();
        }
        public void ManageMemberCards()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int memberId)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            var member = gymService.GetMemberById(memberId);

            switch (member.CardStatus)
            {
                case MemberCard.Active:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  The member's card is "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("active!"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("  What do you want to do with the card?");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [1] "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.DarkBlue; Console.WriteLine("Freeze card"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [2] "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Terminate card"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  [X] Exit");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==================================+");
                    Console.ResetColor();

                    string activeChoice = Console.ReadLine();

                    if (activeChoice == "1")
                    {
                        gymService.UpdateCard(MemberCard.Frozen, memberId);
                    }
                    else if (activeChoice == "2")
                    {
                        gymService.UpdateCard(MemberCard.Terminated, memberId);
                    }
                    else if (activeChoice == "x")
                    {
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Invalid choice!");
                        Console.ResetColor();
                        Pause();
                        return;
                    }

                    break;

                case MemberCard.Frozen:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  The member's card is "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("frozen!"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("  What do you want to do with the card?");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [1] "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Activate card"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [2] "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Terminate card"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  [X] Exit");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();

                    string frozenChoice = Console.ReadLine();

                    if (frozenChoice == "1") gymService.UpdateCard(MemberCard.Active, memberId);

                    else if (frozenChoice == "2") gymService.UpdateCard(MemberCard.Terminated, memberId);

                    else if (frozenChoice == "x") return;

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Invalid choice!");
                        Console.ResetColor();
                        Pause();
                        return;
                    }

                    break;

                case MemberCard.Terminated:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  The member's card is "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("terminated!"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("  What do you want to do with the card?");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [1] "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Activate card"); Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  [X] Exit");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();

                    string terminatedChoice = Console.ReadLine();

                    if (terminatedChoice == "1")
                    {
                        gymService.UpdateCard(MemberCard.Active, memberId);
                    }
                    else if (terminatedChoice == "x")
                    {
                        return;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Invalid choice!");
                        Console.ResetColor();
                    }

                    break;
            }
            Pause();
        }//Done
        public void ManageSubsription()//Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int mChoice)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            List<Subscribtion> subs = Enum.GetValues(typeof(Subscribtion)).Cast<Subscribtion>().ToList();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("To what plan do you want to change? (Write the plan)");
            Console.ResetColor();
            foreach (var sub in subs)
            {
                if (sub != gymService.GetMemberById(mChoice).SubscribtionType)
                {
                    Console.WriteLine(sub);
                }
            }
            //Subscribtion newSub = (Subscribtion)Enum.Parse(typeof(Subscribtion), Console.ReadLine());
            if (Enum.TryParse(Console.ReadLine(), out Subscribtion newSub)) { Console.WriteLine("Invalid Input"); Pause(); return; }
            gymService.UpdateSub(newSub, mChoice);
        }

        //workout UI

        public static void WorkoutUI()//Done
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  ==== WORKOUT MANAGEMENT ====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Create workout");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Edit workout");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [3] "); Console.ResetColor(); Console.WriteLine("Show workout");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  [X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
        }
        public void CreateWorkout()//Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("!!! NOTE THAT THIS WORKOUT IS USABLE ONLY ONCE IN THIS VERSION !!!");
            Console.WriteLine();
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int WId)) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid Input"); Console.ResetColor(); Pause(); return; }
            Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("What should be the name of the workout?: "); Console.ResetColor();
            string Winput = Console.ReadLine();
            if (int.TryParse(Winput, out int Wnumber) || string.IsNullOrWhiteSpace(Winput)) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid Input"); Console.ResetColor(); Pause(); return; }
            string WName = Winput;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Add exercises to the workout:");
            Console.ResetColor();
            List<Exercises> exercises = new List<Exercises>();
            while (true)
            {
                exercises.Add(AddExercise());
                Console.Write("Do you want to add another exercise? "); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("(yes/no)");
                Console.ResetColor();
                string choice = Console.ReadLine();
                if (choice.ToLower() == "no")
                    break;
            }

            gymService.CreateWorkout(WId, WName, exercises);
            Pause();
        }
        public void EditWorkout()//Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int memberId)) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid Input"); Console.ResetColor();  Pause(); return; }

            List<Workouts> workouts = gymService.GetWorkoutsByMemberId(memberId);
            if(workouts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You do not have any workouts created");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Your workouts:");
            Console.ResetColor();

            foreach (var workout in workouts)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"  [{workout.Id}]"); Console.ResetColor(); Console.WriteLine($" Name: {workout.Name}");
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Select the workout by ID: ");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int workoutId)) { Console.WriteLine("Invalid Input"); Pause(); return; }

            Workouts selectedWorkout = gymService.GetWorkoutById(workoutId);
            if (workouts.Count == 0)
            {
                Console.WriteLine("You do not have any workouts created");
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  == What changes to implement ==");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1]  "); Console.ResetColor(); Console.WriteLine("Change workout name");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2]  "); Console.ResetColor(); Console.WriteLine("Add exercise");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [3]  "); Console.ResetColor(); Console.WriteLine("Remove exercise");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=================================+");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int choice)) { Console.WriteLine("Invalid Input"); Pause(); return; }

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Enter new workout name: ");
                    Console.ResetColor();
                    
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input)) { Console.WriteLine("Invalid Input"); Pause(); return; }
                    selectedWorkout.Name = input;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Enter details for the new exercise: ");
                    Console.ResetColor();
                    Exercises newExercise = AddExercise();
                    selectedWorkout.Exercises.Add(newExercise);
                    break;

                case 3:
                    Console.WriteLine("Exercises:");

                    int index = 1;
                    foreach (var exercise in selectedWorkout.Exercises)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"[{index}] "); Console.ResetColor(); Console.Write($"{ exercise.Name}");
                        index++;
                    }

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Choose exercise ID to remove");
                    Console.ResetColor();
                    if (!int.TryParse(Console.ReadLine(), out int removeIndex)) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid Input"); Console.ResetColor(); Pause(); return; }
                    removeIndex--;

                    if (removeIndex >= 0 && removeIndex < selectedWorkout.Exercises.Count)
                    {
                        var exerciseToRemove = selectedWorkout.Exercises.ElementAt(removeIndex);
                        selectedWorkout.Exercises.Remove(exerciseToRemove);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Invalid choice!");
                        Console.ResetColor();
                        Pause();
                        return;
                    }

                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid option!");
                    Console.ResetColor();
                    Pause();
                    break;
            }

            gymService.Save(selectedWorkout);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Workout updated");
            Console.ResetColor();
            Pause();
        }
        public void ShowWorkout()// needs to show the workout by a specified id and the exercises in it;Done
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            if (!int.TryParse(Console.ReadLine(), out int MId)) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid Input"); Console.ResetColor(); Pause(); return; }

            List<Workouts> workouts = gymService.GetWorkoutsByMemberId(MId);
            if (workouts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You do not have any workouts created");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Workouts:");
            Console.ResetColor();

            foreach (var workout in workouts)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{workout.Id}]"); Console.ResetColor(); Console.WriteLine($" Name: {workout.Name}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Exercises:");
                Console.ResetColor();

                foreach (var exercise in workout.Exercises)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"- {exercise.Name}");
                    Console.ResetColor();
                }
            }

            Pause();
        }
        public void CheckGymBusyness() //get the availability of each trainer; Done
        {
            var trainers = gymService.GetTrainers();
            if( trainers.Count == 0)
            {
                Console.WriteLine("There are no trainers created");
                Pause(); 
                return;
            }
            int totalMembers = 0;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("     === GYM BUSYNESS ===");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=============================+");
            Console.ResetColor();

            foreach (var trainer in trainers)
            {
                Console.Write($"{trainer.FirstName} {trainer.LastName} has "); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write($"[{trainer.Members.Count}]"); Console.ResetColor(); Console.Write("members.");
                totalMembers += trainer.Members.Count;
            }

            Console.WriteLine();
            Console.Write($"Total members training: "); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"[{totalMembers}]"); Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=============================+");
            Console.ResetColor();

            Pause();
        }
        public void CheckMostUsedExercises() //Done
        {
            var members = gymService.GetMembers();
            if (members.Count == 0)
            {
                Console.WriteLine("There are no member created");
                Pause();
                return;
            }

            List<string> allExercises = new List<string>();

            // get all exercises
            foreach (var member in members)
            {
                foreach (var workout in member.Progress)
                {
                    foreach (var exercise in workout.Exercises)
                    {
                        allExercises.Add(exercise.Name);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.WriteLine("  == MOST USED EXERCISE ==");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();

            List<string> checkedExercises = new List<string>();
            string mostUsed = "";
            int maxCount = 0;

            foreach (var ex in allExercises)
            {
                // if it's already counted => skip
                if (checkedExercises.Contains(ex))
                    continue;

                int count = 0;

                // count how much there are
                foreach (var item in allExercises)
                {
                    if (item == ex)
                        count++;
                }

                checkedExercises.Add(ex);

                Console.WriteLine();
                Console.WriteLine($"{ex} -> {count} times");
                Console.WriteLine();

                if (count > maxCount)
                {
                    maxCount = count;
                    mostUsed = ex;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Most used exercise: "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"[{mostUsed}] [{maxCount}]"); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write(" times");
            Console.ResetColor();

            Pause();
        }

        //sub methods

        public Exercises AddExercise()//this will be used with the creation and editing of the workout; Done
        {
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("! ! ! ALL EXERCISES ARE USER-DEFINED AND FULLY CUSTOMIZABLE ! ! !");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Please specify the exercise you would like to include in your workout. Enter the exercise name below:"); 
            Console.ResetColor();
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                throw new Exception("Invalid input");
            };
            Console.ResetColor();
            string name = input;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter your weight in KG: ");
            Console.ResetColor();
            if (!double.TryParse(Console.ReadLine(), out double weight))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                throw new Exception("Invalid Input");
            };
            Console.ResetColor();
            Console.Write("Enter the time duration of the exercise in minutes ");  Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("(whole number): ");
            Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                throw new Exception("Invalid Input");
            };
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("How intense will the exercise be?"); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("For example, running at a slow pace may correspond to an intensity level of approximately 3.5, whereas running at a fast pace may reach an intensity level of 10 or higher.");
            Console.ResetColor();
            if (!double.TryParse(Console.ReadLine(), out double met)) throw new Exception("Invalid Input");//check Exercises.cs for more info about MET
            Pause();
            return new Exercises(name, duration, met, weight);
        }
        private void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Press "); Console.ResetColor(); Console.Write("'Enter'"); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write(" to continue"); Console.ResetColor();
            Console.ReadKey();
        }
    }
}