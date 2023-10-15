namespace ZPets.Domain.Entities.Tutors
{
    public class Tutor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<PetOwnership> Pets { get; set; } = new();

        public void AddOwnership(PetOwnership petOwnership)
        {
            if (Pets.Exists(p => p.PetId == petOwnership.PetId)) return;

            Pets.Add(petOwnership);
        }

        public void Update(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}
