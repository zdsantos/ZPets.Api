using ZPets.Domain.Entities.Pets;

namespace ZPets.Domain.Dto
{
    public class PetDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float ActualWeight { get; set; }
        public string Breed { get; set; }
        public Gender Gender { get; set; }
        public string PictureUrl { get; set; }
        public List<Vaccine> Vaccines { get; set; } = new();
        public List<Weight> Weights { get; set; } = new();
    }
}
