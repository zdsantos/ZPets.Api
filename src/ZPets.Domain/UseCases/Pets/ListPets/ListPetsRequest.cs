using ZPets.Domain.Shared.Interfaces;

namespace ZPets.Domain.UseCases.Pets.ListPets
{
    public class ListPetsRequest : IRequest
    {
        public string TutorId { get; set; }
        public bool OnlyOwned { get; set; }
    }
}