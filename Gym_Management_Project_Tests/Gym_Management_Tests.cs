using Gym_Management__Project_.APP;
using Gym_Management__Project_.ConsoleUI;
using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using Gym_Management__Project_.INFRASTRUCTURE.EFRepositories;
using Microsoft.EntityFrameworkCore;
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
        public void ExerciseConstructor_ShouldCreateExercise_WhenDataIsValid()
        {
            var exercise = new Exercises("Running", 60, 8, 70);

            Assert.That(exercise.Name, Is.EqualTo("Running"));
        }
        [Test]
        public void ExerciseConstructor_ShouldThrow_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Exercises("", 60, 8, 70));
        }
        [Test]
        public void ExerciseConstructor_ShouldThrow_WhenDurationIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
                new Exercises("Running", 0, 8, 70));
        }
        [Test]
        public void ExerciseConstructor_ShouldThrow_WhenMetIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
                new Exercises("Running", 60, 0, 70));
        }
        [Test]
        public void CalculateCalories_ShouldReturnCorrectValue()
        {
            var exercise = new Exercises("Running", 60, 8, 70);

            Assert.That(exercise.CaloriesBurnt, Is.EqualTo(560));
        }
        [Test]
        public void CalculateCalories_ShouldThrow_WhenWeightIsNegative()
        {
            var exercise = new Exercises("Running", 60, 8, 70);

            Assert.Throws<ArgumentException>(() =>
                exercise.CalculateCalories(-5));
        }
        [Test]
        public void MemberConstructor_ShouldCreateMember()
        {
            var member = new Members(
                1,
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            Assert.That(member.FirstName, Is.EqualTo("Ivan"));
        }
        [Test]
        public void MemberConstructor_ShouldThrow_WhenIdIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
                new Members(
                    -1,
                    "Ivan",
                    "Petrov",
                    new List<Workouts>(),
                    Subscribtion.Month));
        }
        [Test]
        public void MemberConstructor_ShouldThrow_WhenFirstNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Members(
                    1,
                    "",
                    "Petrov",
                    new List<Workouts>(),
                    Subscribtion.Month));
        }
        [Test]
        public void MemberConstructor_ShouldThrow_WhenLastNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
                new Members(
                    1,
                    "Ivan",
                    "",
                    new List<Workouts>(),
                    Subscribtion.Month));
        }
        [Test]
        public void NewMember_ShouldHaveActiveCard()
        {
            var member = new Members(
                1,
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            Assert.That(member.CardStatus, Is.EqualTo(MemberCard.Active));
        }
        [Test]
        public void HasTrainer_ShouldBeTrue_ForTrainerSubscription()
        {
            var member = new Members(
                1,
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.MonthTrainer);

            Assert.That(member.HasTrainer, Is.True);
        }
        [Test]
        public void HasTrainer_ShouldBeFalse_ForNormalSubscription()
        {
            var member = new Members(
                1,
                "Ivan",
                "Petrov",
                new List<Workouts>(),
                Subscribtion.Month);

            Assert.That(member.HasTrainer, Is.False);
        }
        [Test]
        public void TrainerConstructor_ShouldCreateTrainer()
        {
            var trainer = new Trainers(
                1,
                "John",
                "Smith",
                new List<Members>());

            Assert.That(trainer.FirstName, Is.EqualTo("John"));
        }
        [Test]
        public void TrainerConstructor_ShouldThrow_WhenIdIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
                new Trainers(
                    -1,
                    "John",
                    "Smith",
                    new List<Members>()));
        }
        [Test]
        public void NewTrainer_ShouldBeAvailable()
        {
            var trainer = new Trainers(
                1,
                "John",
                "Smith",
                new List<Members>());

            Assert.That(trainer.IsAvailable, Is.True);
        }
        [Test]
        public void WorkoutConstructor_ShouldCreateWorkout()
        {
            var workout = new Workouts(
                1,
                1,
                "Leg Day",
                new List<Exercises>());

            Assert.That(workout.Name, Is.EqualTo("Leg Day"));
        }

        [Test]
        public void Workout_ShouldNotBeCompletedByDefault()
        {
            var workout = new Workouts(
                1,
                1,
                "Leg Day",
                new List<Exercises>());

            Assert.That(workout.IsCompleted, Is.False);
        }
        [Test]
        public void GetTotalCalories_ShouldCalculateCorrectly()
        {
            var exercise = new Exercises("Running", 60, 8, 70);

            var workout = new Workouts(
                1,
                1,
                "Cardio",
                new List<Exercises> { exercise });

            workout.IsCompleted = true;

            var member = new Members(
                1,
                "Ivan",
                "Petrov",
                new List<Workouts> { workout },
                Subscribtion.Month);

            member.GetTotalCalories();

            Assert.That(member.TotalCaloriesBurnt, Is.EqualTo(560));
        }
        [Test]
        public void Progress_ShouldReturnOnlyCompletedWorkouts()
        {
            var completed = new Workouts(1, 1, "A", new List<Exercises>());
            completed.IsCompleted = true;

            var active = new Workouts(2, 1, "B", new List<Exercises>());

            var member = new Members(
                1,
                "Ivan",
                "Petrov",
                new List<Workouts> { completed, active },
                Subscribtion.Month);

            Assert.That(member.Progress.Count(), Is.EqualTo(1));
        }
        [Test]
        public void CreatedWorkouts_ShouldReturnOnlyUnfinishedWorkouts()
        {
            var completed = new Workouts(1, 1, "A", new List<Exercises>());
            completed.IsCompleted = true;

            var active = new Workouts(2, 1, "B", new List<Exercises>());

            var member = new Members(
                1,
                "Ivan",
                "Petrov",
                new List<Workouts> { completed, active },
                Subscribtion.Month);

            Assert.That(member.CreatedWorkouts.Count(), Is.EqualTo(1));
        }
    }
}
