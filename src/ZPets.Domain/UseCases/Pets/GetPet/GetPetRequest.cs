﻿namespace ZPets.Domain.UseCases.Pets.GetPet
{
    public class GetPetRequest
    {
        public Guid PetId { get; set; }
        public Guid TutorId { get; set; }
    }
}
