namespace ZPets.Domain.Entities.Pets
{
    public class Weight
    {
        public short Id { get; set; }
        public string PetId { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }

        public Pet Pet { get; set; }
    }
}