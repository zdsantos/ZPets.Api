namespace ZPets.Domain.Entities.Pets
{
    public class Vaccine
    {
        public short Id { get; set; }
        public string PetId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Pet Pet { get; set; }

        public static Vaccine Create(string petId, string name, DateTime date)
        {
            return new Vaccine()
            {
                PetId = petId,
                Name = name,
                Date = date
            };
        }
    }
}