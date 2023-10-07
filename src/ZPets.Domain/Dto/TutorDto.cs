namespace ZPets.Domain.Dto
{
    public class TutorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<PetDto> Pets { get; set; } = new();
    }
}
