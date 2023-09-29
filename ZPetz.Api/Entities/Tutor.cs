namespace ZPets.Api.Entities
{
    public class Tutor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Pet> Pets { get; set; } = new();
    }
}
