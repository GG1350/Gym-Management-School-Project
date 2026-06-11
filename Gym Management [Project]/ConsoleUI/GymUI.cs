using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace Gym_Management__Project_.ConsoleUI
{
    public class GymUI
    {
        private readonly GymService gymService;
        public GymUI(GymService service)
        {
            this.gymService = service;
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
                        Winput = Console.ReadLine();
                        switch (Winput)
                        {
                            case "1":
                                MemberUI();
                                Winput = Console.ReadLine();
                                switch (Winput)
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
                                Winput = Console.ReadLine();
                                switch (Winput)
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
                                Winput = Console.ReadLine();
                                switch (Winput)
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
                                 Winput = Console.ReadLine();
                                switch (Winput)
                                {   case "1":
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
                                break;
                            case "6":
                                break;
                        }
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
            Console.Write("  [6] "); Console.ResetColor(); Console.WriteLine("Most Exercise");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  [X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
        }





        public static void MemberUI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  ==== MEMBER MANAGEMENT ====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
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
            Console.WriteLine("+=============================+");
            Console.ResetColor();
        }





        private void AddMember()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("First name: ");
            Console.ResetColor();
            string FName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Last name: ");
            Console.ResetColor();
            string LName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the ID of the subscription plan you want");
            Console.ResetColor();
            foreach (Subscribtion s in Enum.GetValues(typeof(Subscribtion)))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{(int)s}] - "); Console.ResetColor(); Console.WriteLine($"{s}");
            }
            var id = int.Parse(Console.ReadLine());
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





        private void BookTraining()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            var members = gymService.GetMembers();
            int memberId = int.Parse(Console.ReadLine()) - 1;
            if (memberId < 0 || memberId >= members.Count) Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid member ID!"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the ID of the trainer you want");
            Console.ResetColor();
            var trainers = gymService.GetTrainers();
            foreach (var t in trainers)
            {
                if (t.IsAvailable) Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write($"{t.Id}"); Console.ResetColor(); Console.WriteLine($"{t.FirstName} {t.LastName}");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Type your choice: ");
            Console.ResetColor();
            int trainerId = int.Parse(Console.ReadLine());
            
            if (trainerId == 0 || trainerId > trainers.Count) Console.ForegroundColor = ConsoleColor.DarkYellow;  Console.WriteLine("Invalid trainer id!"); Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the workout ID you want to book");
            Console.ResetColor();
            if (members[memberId].Workouts.Count < 1) Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("You have no workouts created!"); Console.ResetColor();
            foreach (var w in members[memberId].Workouts)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write(w.Id); Console.ResetColor(); Console.Write(w.Name); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("Exercises:"); Console.Write( w.Exercises); Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Write your choice");
            Console.ResetColor();

            int workoutId = int.Parse(Console.ReadLine());
            if (workoutId == 0 || workoutId > members[memberId].Workouts.Count) Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid workout id"); Console.ResetColor();
            //actual booking
            gymService.BookTraining(memberId, workoutId, trainerId, "book");

            members[memberId].GetTotalCalories();
            Pause();
        }//validations





        private void UnbookTraining() //validations
        {
            Console.WriteLine("Enter your member ID");
            var members = gymService.GetMembers();
            int memberId = int.Parse(Console.ReadLine()) - 1;

            if (memberId < 0 || memberId >= members.Count)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid member id!");
                Console.ResetColor();
                Pause();
                return;
            }
            if (members[memberId].Trainer == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("This member has no trainer booked!");
                Console.ResetColor();
                Pause();
                return;
            }

            var trainers = gymService.GetTrainers();
            int trainerId = 0;
            int workoutId = members[memberId].Progress.ToList()[members[memberId].Progress.Count() - 1].Id;
            foreach (var t in trainers)
            {
                if (t.Members.Contains(members[memberId]))
                {
                    trainerId = t.Id;
                }
            }

            gymService.BookTraining(memberId, workoutId, trainerId, "unbook");
            Pause();
        }





        private void ShowMembers()//DESIGN CORECTION
        {
            var members = gymService.GetMembers();
            foreach (var m in members)
                Console.WriteLine($"{m.Id} {m.FirstName} {m.LastName}");
        }





        private void CheckProgress() //calories; visits; validations
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            int id = int.Parse(Console.ReadLine());

            var member = gymService.GetMemberById(id);

            member.GetTotalCalories();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Completed workouts: {member.Progress.Count()}");
            Console.WriteLine($"Calories burnt: {member.TotalCaloriesBurnt}");
            Console.ResetColor();

            Pause();
        }





















        public static void TrainerUI()
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





        private void AddTrainer()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("First name: ");
            Console.ResetColor();
            string FName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Last name: ");
            Console.ResetColor();
            string LName = Console.ReadLine();
            List<Members> members = new List<Members>();
            gymService.CreateTrainer(FName, LName, members);
        }//validations





        private void ShowTrainers()
        {
            var trainers = gymService.GetTrainers();
            foreach (var t in trainers)
            {
                string availability = t.IsAvailable ? "Available" : "Not Available";
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{t.Id}] "); Console.ResetColor(); Console.WriteLine($"{t.FirstName} {t.LastName} {availability}");
            }
            Pause();
        }//validations





        private void CheckTrainer()//availability and members; validations
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter trainer ID");
            Console.ResetColor();
            int id = int.Parse(Console.ReadLine());

            var trainer = gymService.GetTrainerById(id);

            if (trainer == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Trainer not found!");
                Console.ResetColor();
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





        private void ManageTrainerTimetable() //maybe should happen with unbook training; validations
        {
            var members = gymService.GetMembers();
            var trainers = gymService.GetTrainers();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter the trainer ID of the trainer's timetable you want to change");
            int tChoice = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("== What do you want to do ==");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Unbook training");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Book training");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    foreach (var m in members)
                    {
                        if (m == trainers[tChoice].Members.ToList()[0])
                        {
                            gymService.BookTraining(m.Id, m.Progress.Count(), tChoice, "unbook");
                        }
                    }
                    break;
                case 2:
                    foreach (var m in members)
                    {
                        if (m == trainers[tChoice].Members.ToList()[0])
                        {
                            gymService.BookTraining(m.Id, m.Progress.Count(), tChoice, "book");
                        }
                    }
                    break;
            }
        }





        private void GetTrainingHistory() //the member's progress; validations
        {
            var members = gymService.GetMembers();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter member ID");
            Console.ResetColor();
            foreach (var m in members)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{m.Id}] "); Console.ResetColor(); Console.WriteLine($"{m.FirstName} {m.LastName}");
            }
            int id = int.Parse(Console.ReadLine());
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





        private void CheckActiveMembers() //members with active subscription; validations
        {
            var members = gymService.GetMembers();

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
        private void ManageMemberCards()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            int memberId = int.Parse(Console.ReadLine());
            var member = gymService.GetMemberById(memberId);

            switch (member.CardStatus)
            {
                case MemberCard.Active:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==============================+");
                    Console.ResetColor();
                    Console.WriteLine("The member's card is active!");
                    Console.WriteLine("What do you want to do with the card?");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==============================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Freeze card");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Terminate card");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  [X] "); Console.ResetColor(); Console.WriteLine("Exit");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+==============================+");
                    Console.ResetColor();

                    int activeChoice = int.Parse(Console.ReadLine());

                    if (activeChoice == 1)
                    {
                        gymService.UpdateCard(MemberCard.Frozen, memberId);
                    }
                    else if (activeChoice == 2)
                    {
                        gymService.UpdateCard(MemberCard.Terminated, memberId);
                    }
                    else if (activeChoice == 3)
                    {
                        return;
                    }
                    else Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid choice!"); Console.ResetColor();

                    break;

                case MemberCard.Frozen:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();
                    Console.WriteLine("The member's card is frozen!");
                    Console.WriteLine("What do you want to do with the card?");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Activate card");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Terminate card");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  [X] "); Console.ResetColor(); Console.WriteLine("Exit");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();

                    int frozenChoice = int.Parse(Console.ReadLine());

                    if (frozenChoice == 1)
                    {
                        gymService.UpdateCard(MemberCard.Active, memberId);
                    }
                    else if (frozenChoice == 2)
                    {
                        gymService.UpdateCard(MemberCard.Terminated, memberId);
                    }
                    else if (frozenChoice == 3)
                    {
                        return;
                    }
                    else Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid choice!"); Console.ResetColor();

                    break;

                case MemberCard.Terminated:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();
                    Console.WriteLine("The member's card is terminated!");
                    Console.WriteLine("What do you want to do with the card?");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Activate card");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  [X] "); Console.ResetColor(); Console.WriteLine("Exit");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("+=======================================+");
                    Console.ResetColor();

                    int terminatedChoice = int.Parse(Console.ReadLine());

                    if (terminatedChoice == 1)
                    {
                        gymService.UpdateCard(MemberCard.Active, memberId);
                    }
                    else if (terminatedChoice == 2)
                    {
                        return;
                    }
                    else Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Invalid choice!"); Console.ResetColor();

                    break;
            }
            Pause();
        }//has errors concerned with the sql and gym service; validations
        private void ManageSubsription()//validations
        {
            var members = gymService.GetMembers();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            Console.ResetColor();
            int mChoice = int.Parse(Console.ReadLine());
            List<Subscribtion> subs = Enum.GetValues(typeof(Subscribtion)).Cast<Subscribtion>().ToList();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("To what plan you want ot change?");
            Console.ResetColor();
            foreach (var sub in subs)
            {
                if (sub != members[mChoice].SubscribtionType)
                {
                    Console.WriteLine(sub);
                }
            }
            Subscribtion newSub = (Subscribtion)Enum.Parse(typeof(Subscribtion), Console.ReadLine());
            gymService.UpdateSub(newSub, mChoice);

        }



















        public static void WorkoutUI()
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





        private void CreateWorkout()//validations DESIGN CORECTION
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Which member wants to create a workout?");
            ShowMembers();
            Console.Write("Write your choice: ");
            int WId = int.Parse(Console.ReadLine());
            Console.WriteLine("What should be the name of the workout?");
            Console.Write("Write the name: ");
            string WName = Console.ReadLine();
            Console.WriteLine("Add exercises to the workout:");
            List<Exercises> exercises = new List<Exercises>();
            while (true)
            {
                exercises.Add(AddExercise());
                Console.WriteLine("Do you want to add another exercise? (yes/no)");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "no")
                    break;
            }

            gymService.CreateWorkout(WId, WName, exercises);
            Pause();
        }





        private void EditWorkout()//validations
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            int memberId = int.Parse(Console.ReadLine());

            List<Workouts> workouts = gymService.GetWorkoutsByMemberId(memberId);

            if (workouts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You don't have any workouts!");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Your workouts:");
            Console.ResetColor();

            foreach (var workout in workouts)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{workout.Id}]"); Console.ResetColor(); Console.WriteLine($"| Name: {workout.Name}");
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Select the workout by the ID");
            Console.ResetColor();
            int workoutId = int.Parse(Console.ReadLine());

            Workouts selectedWorkout = gymService.GetWorkoutById(workoutId);

            if (selectedWorkout == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Workout not found!"); Console.ResetColor();
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" == What changes to implement ==");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=================================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [1] "); Console.ResetColor(); Console.WriteLine("Change workout name");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [2] "); Console.ResetColor(); Console.WriteLine("Add exercise");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  [3] "); Console.ResetColor(); Console.WriteLine("Remove exercise");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+=================================+");
            Console.ResetColor();

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Enter new workout name: ");
                    Console.ResetColor();
                    selectedWorkout.Name = Console.ReadLine();
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

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Choose exercise ID to remove");
                    Console.ResetColor();
                    int removeIndex = int.Parse(Console.ReadLine()) - 1;

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
                    }

                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid option!");
                    Console.ResetColor();
                    break;
            }

            gymService.Save(selectedWorkout);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Workout updated");
            Console.ResetColor();
            Pause();
        }





        private void ShowWorkout()//validations; needs to show the workout by a specified id and the exercises in it.
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter your member ID");
            int WId = int.Parse(Console.ReadLine());

            List<Workouts> workouts = gymService.GetWorkoutsByMemberId(WId);

            if (workouts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("This member does not have any workouts!");
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
                Console.Write($"[{workout.Id}]"); Console.ResetColor(); Console.WriteLine($"| Name: {workout.Name}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Exercises:");
                Console.ResetColor();

                foreach (var exercise in workout.Exercises)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"- {exercise.Name}");
                    Console.ResetColor();
                }
            }

            Pause();
        }




















        

        private void CheckGymBusyness() //get the availability of each trainer; validations
        {
            var trainers = gymService.GetTrainers();
            int totalMembers = 0;

            Console.WriteLine("=== GYM BUSYNESS ===");

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.FirstName} {trainer.LastName} has {trainer.Members.Count} members.");
                totalMembers += trainer.Members.Count;
            }

            Console.WriteLine($"Total members training: {totalMembers}");

            Pause();
        }

        private void CheckMostUsedExercises() //validations
        {
            var members = gymService.GetMembers();

            List<string> allExercises = new List<string>();

            // събираме всички упражнения
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

            if (allExercises.Count == 0)
            {
                Console.WriteLine("No exercises found.");
                Pause();
                return;
            }

            Console.WriteLine("=== MOST USED EXERCISES ===");

            List<string> checkedExercises = new List<string>();
            string mostUsed = "";
            int maxCount = 0;

            foreach (var ex in allExercises)
            {
                // ако вече сме го броили -> skip
                if (checkedExercises.Contains(ex))
                    continue;

                int count = 0;

                // броим колко пъти се среща
                foreach (var item in allExercises)
                {
                    if (item == ex)
                        count++;
                }

                checkedExercises.Add(ex);

                Console.WriteLine($"{ex} -> {count} times");

                if (count > maxCount)
                {
                    maxCount = count;
                    mostUsed = ex;
                }
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Most used exercise: {mostUsed} ({maxCount} times)");

            Pause();
        }
        //sub methods
        private Exercises AddExercise()//this will be used with the creation and editing of the workout
        {
            Console.WriteLine("What exercise do you want to add in the workout?(write the name)(!IT IS ALL CUSTOM!)");
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
        private void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }
    }
}