using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.INFRASTRUCTURE;
using Microsoft.EntityFrameworkCore;
using Gym_Management__Project_.INFRASTRUCTURE.EFRepositories;

namespace Gym_Management__Project_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FOR JSON
            //var storage = new FileStorage("Gym.json");
            //IMemberRepository memberRepository = new FileMemberRepository(storage);
            //ITrainersRepository trainersRepository = new FileTrainersRepository(storage);
            //IWorkoutRepository workoutRepository = new FileWorkoutRepository(storage);

            //var service = new GymService(memberRepository, trainersRepository, workoutRepository);
            //var UI = new GymUI(service);

            var options = new DbContextOptionsBuilder<GymDbContext>()
                .UseSqlServer("Server=DESKTOP-VIPRQ43\\LOCALDB;Database=GymDB;Integrated Security=True;TrustServerCertificate=True;")
                .Options;
            var context = new GymDbContext();
            context.Database.EnsureCreated();

            IMemberRepository memberRepository = new EfMemberRepository(context);
            ITrainersRepository trainerRepository = new EFTrainersRepository(context);
            IWorkoutRepository workoutRepository = new EFWorkoutRepository(context);

            var service = new GymService(memberRepository, trainerRepository, workoutRepository);

            var UI  =new GymUI(service);

            UI.Run();
        }
    }
}
