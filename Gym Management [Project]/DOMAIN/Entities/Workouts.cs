using Gym_Management__Project_.DOMAIN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.DOMAIN.Entities
{
    public class Workouts
    {
        public int Id { get; set; }
        public WorkoutType Type { get; set; }
        public List<Exercises> Exercises { get; set; } = new List<Exercises>();
        
        public Workouts(int id, WorkoutType type, List<Exercises> exercises)
        {
            Id = id;
            Type = type;
            Exercises = exercises;
        }

        public void AddExercise(Exercises exercise)
        {
            if (exercise == null) { throw new ArgumentNullException("The given information is not correct"); }
            try
            {
                Exercises.Add(exercise);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the exercise: {ex.Message}");
            }
        }
        public void RemoveExercise(int id)
        {
            if (id < 1) { throw new ArgumentNullException("The Id must be more than 0"); }
            Exercises.RemoveAt(id - 1);
        }
    }
}