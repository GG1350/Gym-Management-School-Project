using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Management__Project_.INFRASTRUCTURE.EFRepositories;
using Microsoft.EntityFrameworkCore;
using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;

namespace Desktop_UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var options = new DbContextOptionsBuilder<GymDbContext>()
                 .UseSqlServer("Server=K308\\SQLEXPRESS;Database=GymDB;Integrated Security=True;TrustServerCertificate=True;")
                 .Options;
            var context = new GymDbContext();
            context.Database.EnsureCreated();

            IMemberRepository memberRepository = new EfMemberRepository(context);
            ITrainersRepository trainerRepository = new EFTrainersRepository(context);
            IWorkoutRepository workoutRepository = new EFWorkoutRepository(context);

            var service = new GymService(memberRepository, trainerRepository, workoutRepository);

            var UI = new GymUI(service);

            UI.Run();

            Application.Run(new Form1());
        }
    }
}
