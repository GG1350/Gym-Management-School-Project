using Gym_Management__Project_.DOMAIN.Entities;
using Gym_Management__Project_.DOMAIN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management__Project_.APP
{
    public class GymService
    {
        private readonly IMemberRepository memberRepository;
        private readonly ITrainersRepository trainersRepository;
        private readonly IWorkoutRepository workoutRepository;

        public GymService(IMemberRepository memberRepository, ITrainersRepository trainersRepository, IWorkoutRepository workoutRepository)
        {
            this.memberRepository = memberRepository;
            this.trainersRepository = trainersRepository;
            this.workoutRepository = workoutRepository;
        }

        public void CreateTrainer(string FName, string LName)
        {
            var Trainer = new Trainers(FName,LName);
        }
        public void CreateMember(string FName, string LName, Subscribtion SubType)
        {
            var Member = new Members(FName,LName,SubType);
        }

        public IReadOnlyList<Trainers> GetTrainers()
        {
            return trainersRepository.GetAll();
        }

        public IReadOnlyList<Members> GetMembers()
        {
            return memberRepository.GetAll();
        }
    }
}
