using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.DOMAIN.Entities;

namespace Gym_Management__Project_
{
    internal class Program
    {
        public static IMemberRepository memberRepository;
        public static ITrainersRepository trainersRepository;
        public static IWorkoutRepository workoutRepository;
        static void Main(string[] args)
        {
            var service = new GymService(memberRepository, trainersRepository, workoutRepository);
            var UI = new GymUI(service);
            List<Members>m=new List<Members>();
            service.CreateTrainer("Марин", "Николов", m);
            service.CreateTrainer("Силвия", "Лилянова", m);
            service.CreateTrainer("Петър", "Петров", m);

            UI.Run();
        }
    }
}
