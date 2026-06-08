using Gym_Management__Project_.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gym_Management__Project_.INFRASTRUCTURE.EFRepositories
{
    public class GymDbContext : DbContext
    {
        public GymDbContext() 
        {
        
        }

        public GymDbContext(DbContextOptions<GymDbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VIPRQ43\\LOCALDB;Database=GymDB;Integrated Security=True;TrustServerCertificate=True;");
            }
        }


        public DbSet<Members> Members { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Workouts> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one trainer to many members
            modelBuilder.Entity<Trainers>(entity =>
            {
                entity.HasKey(t => t.Id);
                
                entity.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasMany(t => t.Members)
                .WithOne(m => m.Trainer)
                .HasForeignKey(m => m.TranerId)
                .IsRequired(false);
            });

            // one member to many workouts
            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(m=> m.CardStatus)
                .IsRequired();

                entity.Property(m => m.SubscribtionType)
                .IsRequired();

                entity.Property(m => m.TotalCaloriesBurnt);

                entity.HasMany(m => m.Workouts)
                .WithOne(w => w.Member)
                .HasForeignKey(w => w.MemberId);
            });

            // one workout to many exercises
            modelBuilder.Entity<Workouts>(entity =>
            {
                entity.HasKey(w => w.Id);

                entity.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity.OwnsMany(w => w.Exercises, exercise =>
                {
                    exercise.ToTable("Exercises");

                    exercise.WithOwner().HasForeignKey("WorkoutId");

                    exercise.Property<int>("Id");

                    exercise.HasKey("Id");

                    exercise.Property(e => e.Name)
                        .HasMaxLength(100)
                        .IsRequired();

                    exercise.Property(e => e.CaloriesBurnt)
                        .IsRequired();
                });
            });
        }
    }
}
