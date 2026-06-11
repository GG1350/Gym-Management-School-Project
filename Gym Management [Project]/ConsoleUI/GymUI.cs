using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }//validations

        private void ShowTrainers()
        {
            var trainers = gymService.GetTrainers();
            foreach (var t in trainers)
            {
                string availability = t.IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"{t.Id} {t.FirstName} {t.LastName} {availability}"); 
            }
            Pause();
        }//validations

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
        private void CreateWorkout()//validations
        {
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
            Console.WriteLine("Which member's workout do you want to edit?");
            ShowMembers();
            Console.Write("Write your choice: ");

            int memberId = int.Parse(Console.ReadLine());

            List<Workouts> workouts = gymService.GetWorkoutsByMemberId(memberId);

            if (workouts.Count == 0)
            {
                Console.WriteLine("This member has no workouts.");
                Pause();
                return;
            }

            Console.WriteLine("Member workouts:");

            foreach (var workout in workouts)
            {
                Console.WriteLine($"ID: {workout.Id} | Name: {workout.Name}");
            }

            Console.Write("Choose workout ID: ");
            int workoutId = int.Parse(Console.ReadLine());

            Workouts selectedWorkout = gymService.GetWorkoutById(workoutId);

            if (selectedWorkout == null)
            {
                Console.WriteLine("Workout not found.");
                Pause();
                return;
            }

            Console.WriteLine("What do you want to edit?");
            Console.WriteLine("1. Change workout name");
            Console.WriteLine("2. Add exercise");
            Console.WriteLine("3. Remove exercise");
            Console.Write("Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new workout name: ");
                    selectedWorkout.Name = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Enter details for the new exercise:");
                    Exercises newExercise = AddExercise();
                    selectedWorkout.Exercises.Add(newExercise);
                    break;

                case 3:
                    Console.WriteLine("Exercises:");

                    int index = 1;
                    foreach (var exercise in selectedWorkout.Exercises)
                    {
                        Console.WriteLine($"{index}. {exercise.Name}");
                        index++;
                    }

                    Console.Write("Choose exercise number to remove: ");
                    int removeIndex = int.Parse(Console.ReadLine()) - 1;

                    if (removeIndex >= 0 && removeIndex < selectedWorkout.Exercises.Count)
                    {
                        var exerciseToRemove = selectedWorkout.Exercises.ElementAt(removeIndex);
                        selectedWorkout.Exercises.Remove(exerciseToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }

                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            gymService.Save(selectedWorkout);

            Console.WriteLine("Workout updated successfully!");//Ще се промени при правенето на дизайна!!!
            Pause();
        }

        private void ShowWorkout()//validations; needs to show the workout by a specified id and the exercises in it.
        {
            Console.WriteLine("Which member's workout do you want to see?");
            ShowMembers();
            Console.Write("Write your choice: ");

            int WId = int.Parse(Console.ReadLine());

            List<Workouts> workouts = gymService.GetWorkoutsByMemberId(WId);

            if (workouts.Count == 0)
            {
                Console.WriteLine("This member does not have any workouts.");
                Pause();
                return;
            }

            Console.WriteLine("Workouts:");

            foreach (var workout in workouts)
            {
                Console.WriteLine($"\nWorkout ID: {workout.Id}");
                Console.WriteLine($"Workout Name: {workout.Name}");
                Console.WriteLine("Exercises:");

                foreach (var exercise in workout.Exercises)
                {
                    Console.WriteLine($"- {exercise.Name}");
                }
            }

            Pause();
        }

        private void BookTraining()
        {
            Console.WriteLine("Who wants to book a training(write the id)?");
            ShowMembers();
            var members = gymService.GetMembers();
            Console.Write("Write your choice: ");
            int memberId = int.Parse(Console.ReadLine());
            if (memberId == 0||memberId>members.Count) Console.WriteLine("Invalid member id!");

            Console.WriteLine("Which available trainer is to be booked(write the id)?");
            var trainers = gymService.GetTrainers();
            foreach (var t in trainers)
            {
                if (t.IsAvailable) Console.WriteLine($"{t.Id} {t.FirstName} {t.LastName}");
            }
            Console.Write("Write your choice: ");
            int trainerId = int.Parse(Console.ReadLine());
            if(trainerId ==0||trainerId>trainers.Count) Console.WriteLine("Invalid trainer id!");

            Console.WriteLine("Which of your workouts do you want to book(write the Id): ");
            if (members[memberId].Workouts.Count < 1) Console.WriteLine("You have no workouts created!");
            foreach(var w in members[memberId].Workouts)
            {
                Console.WriteLine(w.Id + w.Name + "\nExercises:" + w.Exercises);
            }
            Console.Write("Write your choice: ");
            int workoutId = int.Parse(Console.ReadLine());
            if (workoutId == 0 || workoutId > members[memberId].Workouts.Count) Console.WriteLine("Invalid workout id");
            //actual booking
            gymService.BookTraining(memberId, workoutId, trainerId, "book");

            //adding the progress
            members[memberId].progress.Add(members[memberId].Workouts.ToList()[workoutId]);
            members[memberId].GetTotalCalories();
            Pause();
        }//validations

        private void UnbookTraining() //validations
        {
            Console.WriteLine("Who wants to unbook a training (write the id)?");
            ShowMembers();

            var members = gymService.GetMembers();

            Console.Write("Write your choice: ");
            int memberId = int.Parse(Console.ReadLine());

            if (memberId == 0 || memberId > members.Count)
            {
                Console.WriteLine("Invalid member id!");
                Pause();
                return;
            }
            if (members[memberId].Trainer == null)
            {
                Console.WriteLine("This member has no trainer booked!");
                Pause();
                return;
            }

            var trainers = gymService.GetTrainers();
            int trainerId=0;
            int workoutId = members[memberId].progress[members[memberId].progress.Count - 1].Id;
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
        private void CheckProgress() //calories; visits; validations
        {
            Console.WriteLine("Write the member's id whose progress you want to check.");
            ShowMembers();
            Console.Write("Write your choice: ");
            int id = int.Parse(Console.ReadLine());

            var member = gymService.GetMemberById(id);

            member.GetTotalCalories();

            Console.WriteLine($"Completed workouts: {member.progress.Count}");
            Console.WriteLine($"Calories burnt: {member.TotalCaloriesBurnt}");

            Pause();
        }
        private void CheckTrainer()//availability and members; validations
        {
            Console.WriteLine("Which trainer do you want to check? (write the id)");
            ShowTrainers();
            Console.Write("Write your choice: ");
            int id = int.Parse(Console.ReadLine());

            var trainer = gymService.GetTrainerById(id);

            if (trainer == null)
            {
                Console.WriteLine("Trainer not found!");
                return;
            }

            Console.WriteLine($"Name: {trainer.FirstName} {trainer.LastName}  Available: {(trainer.IsAvailable ? "Yes" : "No")}");

            if (trainer.Members.Count == 0)
            {
                Console.WriteLine("No assigned members.");
                Pause();
                return;
            }

            Console.WriteLine("Members:");
            foreach (var member in trainer.Members)
            {
                Console.WriteLine($"{member.Id}");
            }
            Pause();
            return;
        }

        private void ManageTrainerTimetable() //maybe should happen with unbook training; validations
        {
            var members = gymService.GetMembers();
            var trainers = gymService.GetTrainers();
            Console.Write("Which trainer's timetable should be altered: ");
            int tChoice = int.Parse(Console.ReadLine());
            Console.WriteLine("What do you want to do:");
            Console.WriteLine("1) Unbook training");
            Console.WriteLine("2) Book training");
            Console.Write("Write your choide: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    foreach(var m in members)
                    {
                        if (m == trainers[tChoice].Members.ToList()[0])
                        {
                            gymService.BookTraining(m.Id, m.progress.Count, tChoice, "unbook");
                        }
                    }
                    break;
                case 2:
                    foreach (var m in members)
                    {
                        if (m == trainers[tChoice].Members.ToList()[0])
                        {
                            gymService.BookTraining(m.Id, m.progress.Count, tChoice, "book");
                        }
                    }
                        break;
            }
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
                foreach (var workout in member.progress)
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

        private void ManageMemberCards() 
        {
            Console.WriteLine("Choose member by id:");
            ShowMembers();
            Console.Write("Write your choice: ");
            int memberId = int.Parse(Console.ReadLine());
            var member = gymService.GetMemberById(memberId);

            switch (member.CardStatus)
            {
                case MemberCard.Active:
                    Console.WriteLine("The member's card is active.");
                    Console.WriteLine("What do you want to do with the card?");
                    Console.WriteLine("1. Freeze card");
                    Console.WriteLine("2. Terminate card");
                    Console.WriteLine("3. Exit");

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
                    else Console.WriteLine("Invalid choice.");

                    break;

                case MemberCard.Frozen:
                    Console.WriteLine("The member's card is frozen.");
                    Console.WriteLine("What do you want to do with the card?");
                    Console.WriteLine("1. Activate card");
                    Console.WriteLine("2. Terminate card");
                    Console.WriteLine("3. Exit");

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
                    else Console.WriteLine("Invalid choice.");

                    break;

                case MemberCard.Terminated:
                    Console.WriteLine("The member's card is terminated.");
                    Console.WriteLine("What do you want to do with the card?");
                    Console.WriteLine("1. Activate card");
                    Console.WriteLine("2. Exit");

                    int terminatedChoice = int.Parse(Console.ReadLine());

                    if (terminatedChoice == 1)
                    {
                        gymService.UpdateCard(MemberCard.Active, memberId);
                    }
                    else if (terminatedChoice == 2)
                    {
                        return;
                    }
                    else Console.WriteLine("Invalid choice.");

                    break;
            }
            Pause();
        }//has errors concerned with the sql and gym service; validations

        private void GetTrainingHistory() //the member's progress; validations
        {
            var members = gymService.GetMembers();
            Console.WriteLine("Choose member by id:");
            foreach (var m in members)
            {
                Console.WriteLine($"{m.Id} {m.FirstName} {m.LastName}");
            }
            Console.Write("Write your choice:");
            int id = int.Parse(Console.ReadLine());
            var member = gymService.GetMemberById(id);
            Console.WriteLine($"Training history for {member.FirstName} {member.LastName}:");
            foreach (var workout in member.progress)
            {
                Console.WriteLine($"{workout.Id} {workout.Name}");
            }
            Pause();
        }

        private void CheckActiveMembers() //members with active subscription; validations
        {
            var members = gymService.GetMembers();

            Console.WriteLine("Active members:");

            foreach (var member in members)
            {
                if (member.CardStatus == MemberCard.Active)
                {
                    Console.WriteLine($"{member.Id} {member.FirstName} {member.LastName}");
                }
            }

            Pause();
        }

        private void ManageSubsription()//validations
        {
            var members = gymService.GetMembers();
            Console.WriteLine("Which member's subscription do you want to change: ");
            ShowMembers();
            Console.Write("Write your choice: ");
            int mChoice = int.Parse(Console.ReadLine());
            List<Subscribtion> subs = Enum.GetValues(typeof(Subscribtion)).Cast<Subscribtion>().ToList();
            Console.WriteLine("What do you want to change the subscription to?");
            foreach(var sub in subs)
            {
                if (sub != members[mChoice].SubscribtionType)
                {
                    Console.WriteLine(sub);
                }
            }
            Subscribtion newSub = (Subscribtion)Enum.Parse(typeof(Subscribtion), Console.ReadLine());
            gymService.UpdateSub(newSub, mChoice);

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