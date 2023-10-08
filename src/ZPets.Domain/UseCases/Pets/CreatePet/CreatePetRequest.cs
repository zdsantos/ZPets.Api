using ZPets.Domain.Entities.Pets;
using ZPets.Domain.Shared.Interfaces;

namespace ZPets.Domain.UseCases.Pets.CreatePet
{
    public class CreatePetRequest : IRequest
    {
        public string TutorId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float Weight { get; set; }
        public Gender Gender { get; set; }
        public PetType Type { get; set; }
        public string Breed { get; set; }
    }
}
