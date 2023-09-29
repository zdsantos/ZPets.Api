﻿using ZPetz.Api.Entities;

namespace ZPetz.Api.UseCases.Pets.CreatePet
{
    public class CreatePetRequest
    {
        public Guid TutorId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float Weight { get; set; }
        public Gender Gender { get; set; }
        public string Breed { get; set; }
    }
}