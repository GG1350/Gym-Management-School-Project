using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using Gym_Management__Project_.INFRASTRUCTURE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.APP
{
    public class GymService
    {
        private readonly IMemberRepository memberRepository;
        private ITrainersRepository trainersRepository;
        private readonly IWorkoutRepository workoutRepository;

        public GymService(IMemberRepository memberRepository, ITrainersRepository trainersRepository, IWorkoutRepository workoutRepository)
        {
            this.memberRepository = memberRepository;
            this.trainersRepository = trainersRepository;
            this.workoutRepository = workoutRepository;
        }

        public void CreateTrainer(string FName, string LName, List<Members>members)
        {
            Trainers Trainer = new Trainers(0,FName,LName,members);
            trainersRepository.Save(Trainer);
        }
        public void CreateMember(string FName, string LName, List<Workouts> workouts, Subscribtion SubType)
        {
            var Member = new Members(0,FName,LName,workouts,SubType);
            memberRepository.Save(Member);
        }
        public void BookTraining(int memberId, int workoutId,int trainerId,string action)
        {
            memberRepository.Update(memberId, workoutId, action);
            trainersRepository.Update(trainerId, action);
        }

        public void CreateWorkout(int memberId, string name, List<Exercises> exercises)
        {
            Workouts Workout = new Workouts(0, memberId, name, exercises);
            workoutRepository.Save(Workout);
        }

        public Members GetMemberById(int memberId)
        {
            return memberRepository.GetById(memberId);
        }

        public IReadOnlyList<Trainers> GetTrainers()
        {
            return trainersRepository.GetAll();
        }

        public IReadOnlyList<Members> GetMembers()
        {
            return memberRepository.GetAll();
        }
        
        public IReadOnlyList<Workouts> GetWorkouts()
        {
            return workoutRepository.GetAll();
        }
    }
}
