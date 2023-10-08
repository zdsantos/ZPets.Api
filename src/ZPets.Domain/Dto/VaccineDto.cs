namespace ZPets.Domain.Dto
{
    public class VaccineDto
    {
        public short Id { get; set; }
        public string PetId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
