using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Gym_Management__Project_.APP;
using Gym_Management__Project_.DOMAIN.Enum;

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
                string Winput;
                switch (input)
                {
                    case "1":
                        CreateMemberAccount();
                        break;
                    case "2":
                        ShowWorkoutPlan();
                        Winput = Console.ReadLine();
                        switch (Winput)
                        {
                            case "1":
                                AddExercise();
                                break;
                            case "2":
                                RemoveExercise();
                                break;
                        }
                        break;
                    case "3":
                        AddTransaction();
                        break;
                    case "4":
                        ShowAccount();
                        break;
                    case "5":
                        ShowTransaction();
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
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("==== GYM SYSTEM ====\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[1] "); Console.ResetColor(); Console.WriteLine("Create MEMBER account");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[2] "); Console.ResetColor(); Console.WriteLine("Show plan");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[3] "); Console.ResetColor(); Console.WriteLine("Trainers");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[4] "); Console.ResetColor(); Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[5] "); Console.ResetColor(); Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[X] Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+==============================+");
            Console.WriteLine("+==============================+");
            Console.ResetColor();
        }

        private void CreateMemberAccount()
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

        private void ShowTransaction()
        {

        }

        private void ShowAccount()
        {

        }

        private void AddTransaction()
        {

        }

        private void ShowWorkoutPlan()
        {

        }

        private void AddExercise()
        {

        }

        private void RemoveExercise()
        {

        }
    }
}
