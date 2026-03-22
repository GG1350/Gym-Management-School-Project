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
        public int DurationMinutes { get; set; }
        public double MET { get; set; }

        public Exercises(string name, int durationMinutes, double met)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Exercise name is required");

            if (durationMinutes <= 0) throw new ArgumentException("Duration must be greater than 0");

            if (met <= 0) throw new ArgumentException("MET must be greater than 0");

            Name = name;
            DurationMinutes = durationMinutes;
            MET = met;
        }

        public double CalculateCalories(double weightKg)
        {
            if (weightKg <= 0)
                throw new ArgumentException("Weight must be greater than 0");

            //double durationHours = DurationMinutes / 60.0;
            return MET * weightKg * (DurationMinutes/60.0);
        }
    }
}
