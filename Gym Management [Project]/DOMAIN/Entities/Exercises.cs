using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.DOMAIN.Entities
{
    public class Exercises
    {
        public string Name { get; set; } = string.Empty;
        public int DurationMinutes;
        public double MET;
        public double CaloriesBurnt {  get; set; }

        public Exercises() { }

        public Exercises(string name, int durationMinutes, double met, double bodyWeight)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Exercise name is required");

            if (durationMinutes <= 0) throw new ArgumentException("Duration must be greater than 0");

            if (met <= 0) throw new ArgumentException("MET must be greater than 0");

            Name = name;
            DurationMinutes = durationMinutes;
            MET = met;//MET (Metabolic Equivalent of Task) is a unit that estimates the amount of energy used by the body during physical activity,
                      //compared to resting metabolism. A MET value of 1 represents the energy expenditure at rest, while higher values indicate more
                      //intense activities. For example, walking at a moderate pace might have a MET value of around 3.5, while running at a fast pace
                      //could have a MET value of 10 or more.
            CaloriesBurnt = CalculateCalories(bodyWeight);
        }

        public double CalculateCalories(double bodyWeightKg)
        {
            if (bodyWeightKg <= 0)
                throw new ArgumentException("Body weight must be greater than 0");

            //double durationHours = DurationMinutes / 60.0;
            return MET * bodyWeightKg * (DurationMinutes/60.0);
        }
    }
}
