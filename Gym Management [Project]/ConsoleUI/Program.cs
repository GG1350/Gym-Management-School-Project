using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.INFRASTRUCTURE;

namespace Gym_Management__Project_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("Gym.json");
            IMemberRepository memberRepository = new FileMemberRepository(storage);
            ITrainersRepository trainersRepository = new FileTrainersRepository(storage);
            IWorkoutRepository workoutRepository = new FileWorkoutRepository(storage);
            
            var service = new GymService(memberRepository, trainersRepository, workoutRepository);
            var UI = new GymUI(service);

            UI.Run();
        }
    }
}
