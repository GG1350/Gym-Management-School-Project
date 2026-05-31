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

        public GymDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-VIPRQ43\\LOCALDB;Database=GymDB;Integrated Security=True;");

        public DbSet<Members> Members { get; set; }
        public DbSet<Trainers> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainers>(builder =>
            {
                builder.HasMany(t => t.Members)
                .WithOne(t => t.Trainers)
                .HasForeignKey(t=>t.Id);
            });

         
            modelBuilder.Entity<Workouts>(entity =>
            {
                entity.OwnsMany(w => w.Exercises, exercise =>
                {
                    exercise.WithOwner().HasForeignKey("WorkoutPlanId");

                    exercise.Property<int>("Id");

                    exercise.HasKey("Id");

                    exercise.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(100);

                    exercise.Property(e => e.DurationMinutes)
                        .IsRequired();

                    exercise.Property(e => e.MET)
                        .IsRequired();
                });
            });
        //modelBuilder.Entity<Members>(builder =>
        //{
        //    builder.OwnsOne(m=>m., money =>
        //    {
        //        money.Property(m => m.Amount)
        //        .HasColumnName("Amount").HasColumnType("decimal(18,2)")
        //        .IsRequired();
        //    });//for migration creating Add-Migration InitialMigration
        //});
    }
    }
}
