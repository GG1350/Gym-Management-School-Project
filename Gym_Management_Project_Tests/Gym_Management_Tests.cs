using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_Project_Tests
{
    [TestFixture]
    public class Gym_Management_Tests
    {
        private readonly GymService gymService= new GymService();
        GymUI UI = new GymUI(gymSe);
        [Test]
        public void CreateMember_ValidInput_ShouldCreateMember()
        {
            var input =
            @"Ivan
            Petrov
            1
            ";

            Console.SetIn(new StringReader(input));

            int before = gymService.GetMembers().Count();

            GymUI.CreateMember();

            int after = gymService.GetMembers().Count();

            Assert.That(after, Is.EqualTo(before + 1));
        }
    }
}
