using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using Gym_Management__Project_.INFRASTRUCTURE.EFRepositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_Project_Tests
{
    [TestFixture]
    public class Gym_Management_Tests_Services
    {
        GymService gymService;
        GymUI gymUI;
        [SetUp]
        public void Setup()
        {
            var options =
                new DbContextOptionsBuilder<GymDbContext>()
                    .Options;

            var context =
                new GymDbContext(options);

            var memberRepo =
                new EfMemberRepository(context);

            var trainerRepo =
                new EFTrainersRepository(context);

            var workoutRepo =
                new EFWorkoutRepository(context);

            gymService = new GymService(
                memberRepo,
                trainerRepo,
                workoutRepo);

            gymUI = new GymUI(gymService);
        }
        [Test]
        public void CreateMember_ShouldIncreaseMembersCount()
        {
            int before = gymService.GetMembers().Count;

            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            int after = gymService.GetMembers().Count;

            Assert.That(after, Is.EqualTo(before + 1));
        }
        [Test]
        public void CreateMember_ShouldStoreCorrectFirstName()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            var member = gymService.GetMembers().First();

            Assert.That(member.FirstName, Is.EqualTo("Ivan"));
        }

        [Test]
        public void CreateMember_ShouldStoreCorrectSubscription()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Year);

            var member = gymService.GetMembers().First();

            Assert.That(member.SubscribtionType,
                Is.EqualTo(Subscribtion.Year));
        }
        [Test]
        public void CreateMember_ShouldCreateActiveCard()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            var member = gymService.GetMembers().First();

            Assert.That(member.CardStatus,
                Is.EqualTo(MemberCard.Active));
        }
        [Test]
        public void CreateTrainer_ShouldIncreaseTrainerCount()
        {
            int before = gymService.GetTrainers().Count;

            gymService.CreateTrainer(
                "John",
                "Smith",
                new List<Members>());

            int after = gymService.GetTrainers().Count;

            Assert.That(after, Is.EqualTo(before + 1));
        }
        [Test]
        public void CreateTrainer_ShouldStoreCorrectName()
        {
            gymService.CreateTrainer(
                "John",
                "Smith",
                new List<Members>());

            var trainer = gymService.GetTrainers().First();

            Assert.That(trainer.FirstName, Is.EqualTo("John"));
        }
        [Test]
        public void CreateTrainer_ShouldBeAvailableByDefault()
        {
            gymService.CreateTrainer(
                "John",
                "Smith",
                new List<Members>());

            var trainer = gymService.GetTrainers().First();

            Assert.That(trainer.IsAvailable, Is.True);
        }
        [Test]
        public void CreateWorkout_ShouldIncreaseWorkoutCount()
        {
            gymService.CreateWorkout(
                1,
                "Leg Day",
                new List<Exercises>());

            Assert.That(
                gymService.GetWorkouts().Count,
                Is.EqualTo(1));
        }
        [Test]
        public void CreateWorkout_ShouldStoreName()
        {
            gymService.CreateWorkout(
                1,
                "Leg Day",
                new List<Exercises>());

            var workout = gymService.GetWorkouts().First();

            Assert.That(workout.Name, Is.EqualTo("Leg Day"));
        }
        [Test]
        public void CreateWorkout_ShouldStoreMemberId()
        {
            gymService.CreateWorkout(
                5,
                "Cardio",
                new List<Exercises>());

            var workout = gymService.GetWorkouts().First();

            Assert.That(workout.MemberId, Is.EqualTo(5));
        }
        [Test]
        public void GetWorkoutsByMemberId_ShouldReturnCorrectWorkouts()
        {
            gymService.CreateWorkout(1, "A", new List<Exercises>());
            gymService.CreateWorkout(1, "B", new List<Exercises>());
            gymService.CreateWorkout(2, "C", new List<Exercises>());

            var workouts =
                gymService.GetWorkoutsByMemberId(1);

            Assert.That(workouts.Count, Is.EqualTo(2));
        }
        [Test]
        public void GetWorkoutsByMemberId_WhenNoWorkouts_ShouldReturnEmptyCollection()
        {
            var workouts =
                gymService.GetWorkoutsByMemberId(999);

            Assert.That(workouts, Is.Empty);
        }
        [Test]
        public void UpdateCard_ShouldChangeStatus()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            int id = gymService.GetMembers().First().Id;

            gymService.UpdateCard(
                MemberCard.Frozen,
                id);

            var member =
                gymService.GetMemberById(id);

            Assert.That(member.CardStatus,
                Is.EqualTo(MemberCard.Frozen));
        }
        [Test]
        public void UpdateCard_InvalidMember_ShouldThrow()
        {
            Assert.Throws<Exception>(() =>
                gymService.UpdateCard(
                    MemberCard.Frozen,
                    999));
        }
        [Test]
        public void UpdateSub_ShouldChangeSubscription()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            int id = gymService.GetMembers().First().Id;

            gymService.UpdateSub(
                Subscribtion.Year,
                id);

            var member =
                gymService.GetMemberById(id);

            Assert.That(member.SubscribtionType,
                Is.EqualTo(Subscribtion.Year));
        }
        [Test]
        public void UpdateSub_InvalidMember_ShouldThrow()
        {
            Assert.Throws<Exception>(() =>
                gymService.UpdateSub(
                    Subscribtion.Year,
                    999));
        }
        [Test]
        public void GetMemberById_InvalidId_ShouldThrow()
        {
            Assert.Throws<Exception>(() =>
                gymService.GetMemberById(999));
        }
        [Test]
        public void GetTrainerById_InvalidId_ShouldThrow()
        {
            Assert.Throws<Exception>(() =>
                gymService.GetTrainerById(999));
        }
        [Test]
        public void BookTraining_ShouldAssignTrainerToMember()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.MonthTrainer);

            gymService.CreateTrainer(
                "John",
                "Smith",
                new List<Members>());

            var member = gymService.GetMembers().First();
            var trainer = gymService.GetTrainers().First();

            gymService.CreateWorkout(
                member.Id,
                "Cardio",
                new List<Exercises>());

            var workout = gymService.GetWorkouts().First();

            gymService.BookTraining(
                member.Id,
                workout.Id,
                trainer.Id,
                "book");

            member = gymService.GetMemberById(member.Id);

            Assert.That(member.TranerId,
                Is.EqualTo(trainer.Id));
        }
        [Test]
        public void BookTraining_ShouldMarkWorkoutCompleted()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.MonthTrainer);

            gymService.CreateTrainer(
                "John",
                "Smith",
                new List<Members>());

            var member = gymService.GetMembers().First();
            var trainer = gymService.GetTrainers().First();

            gymService.CreateWorkout(
                member.Id,
                "Cardio",
                new List<Exercises>());

            var workout = gymService.GetWorkouts().First();

            gymService.BookTraining(
                member.Id,
                workout.Id,
                trainer.Id,
                "book");

            workout =
                gymService.GetWorkoutById(workout.Id);

            Assert.That(workout.IsCompleted,
                Is.True);
        }
        [Test]
        public void BookTraining_ShouldMakeTrainerUnavailable()
        {
            gymService.CreateMember(
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.MonthTrainer);

            gymService.CreateTrainer(
                "John",
                "Smith",
                new List<Members>());

            var member = gymService.GetMembers().First();
            var trainer = gymService.GetTrainers().First();

            gymService.CreateWorkout(
                member.Id,
                "Cardio",
                new List<Exercises>());

            var workout = gymService.GetWorkouts().First();

            gymService.BookTraining(
                member.Id,
                workout.Id,
                trainer.Id,
                "book");

            trainer =
                gymService.GetTrainerById(trainer.Id);

            Assert.That(trainer.IsAvailable, Is.False);
        }
    }
}
