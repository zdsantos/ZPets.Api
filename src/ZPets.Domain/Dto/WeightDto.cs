namespace ZPets.Domain.Dto
{
    public class WeightDto
    {
        public short Id { get; set; }
        public string PetId { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
    }
}
