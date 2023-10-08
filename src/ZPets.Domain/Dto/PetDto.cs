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
        public List<VaccineDto> Vaccines { get; set; } = new();
        public List<WeightDto> Weights { get; set; } = new();
    }
}
