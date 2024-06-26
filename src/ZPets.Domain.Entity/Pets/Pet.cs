﻿using ZPets.Domain.Entities.Tutors;
using System.Linq.Expressions;

namespace ZPets.Domain.Entities.Pets
{
    public class Pet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float ActualWeight { get; set; }
        public PetType Type { get; set; }
        public string Breed { get; set; }
        public Gender Gender { get; set; }
        public string? PictureUrl { get; set; }
        public List<PetOwnership> PetOwners { get; set; } = new();
        public List<Vaccine> Vaccines { get; set; } = new();
        public List<Weight> Weights { get; set; } = new();

        public static Pet Create(string name, DateTime birthDate, PetType type, string breed, Gender gender, float weight)
        {
            var pet = new Pet
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                BirthDate = birthDate,
                Type = type,
                Breed = breed,
                Gender = gender
            };
            
            pet.AddWeight(new Weight { Value = weight, Date = DateTime.UtcNow });
            
            return pet;
        }

        public void AddOwnership(PetOwnership ownership)
        {
            if (PetOwners.Exists(po => po.TutorId == ownership.TutorId)) return;
            
            PetOwners.Add(ownership);
        }

        public void AddWeight(Weight weight)
        {
            Weights ??= new();
            Weights.Add(weight);

            var lastWeight = Weights.OrderByDescending(w => w.Date).First();
            ActualWeight = lastWeight.Value;
        }

        public void AddVaccine(Vaccine vaccine)
        {
            Vaccines ??= new();
            Vaccines.Add(vaccine);
        }

        public bool IsOwnedBy(string tutorId)
        {
            return PetOwners.Find(po => po.TutorId == tutorId) != null;
        }

        public static class Expression
        {
            public static class Criteria
            {
                public static Expression<Func<Pet, bool>> Id(string petId)
                {
                    return p => p.Id == petId;
                }

                public static Expression<Func<Pet, bool>> Tutor(string tutorId, bool onlyOwner)
                {
                    return p => p.PetOwners.Any(po => po.TutorId == tutorId && (po.Type == OwnerType.Owner || !onlyOwner));
                }
            }
        }
    }
}
