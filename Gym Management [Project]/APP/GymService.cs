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
            memberRepository.Update(memberId,trainerId, workoutId, action);
            trainersRepository.Update(trainerId,memberId, action);
        }

        public void CreateWorkout(int memberId, string name, List<Exercises> exercises)
        {
            Workouts Workout = new Workouts(memberId, name, exercises);
            workoutRepository.Save(Workout);
        }

        public void Save(Workouts Workout)
        {
            workoutRepository.Save(Workout);
        }
        public void UpdateWorkout(Workouts Workout)
        {
            workoutRepository.Update(Workout);
        }

        public void UpdateCard(MemberCard memberCard, int memberId)
        {
            memberRepository.UpdateCard(memberCard, memberId);
        }
        public void UpdateSub(Subscribtion sub,int memberId)
        {
            memberRepository.UpdateSub(sub, memberId);
        }

        public List<Workouts> GetWorkoutsByMemberId(int memberId)
        {
            return workoutRepository
                .GetAll()
                .Where(w => w.MemberId == memberId)
                .ToList();
        }

        public Workouts GetWorkoutById(int workoutId)
        {
            return workoutRepository
                .GetAll()
                .FirstOrDefault(w => w.Id == workoutId);
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

        public Trainers GetTrainerById(int trainerId)
        {
            return trainersRepository.GetById(trainerId);
        }
    }
}
