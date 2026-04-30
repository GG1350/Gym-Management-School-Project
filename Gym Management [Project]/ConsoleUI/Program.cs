using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new GymService();
            var UI = new GymUI(service);

            UI.Run();
        }
    }
}
