namespace ZPets.Api.Entities
{
    public class PetOwnership
    {
        public Guid TutorId { get; set; }
        public Guid PetId { get; set; }
        public OwnerType Type { get; set; }
    }

    public enum OwnerType
    {
        Owner,
        Shared,
    }
}