using ZPets.Domain.Entities.Pets;

namespace ZPets.Domain.Entities.Tutors
{
    public class PetOwnership
    {
        public Tutor Tutor { get; set; }
        public Pet Pet { get; set; }

        public Guid TutorId { get; set; }
        public Guid PetId { get; set; }
        public OwnerType Type { get; set; }

        public static PetOwnership Create(Tutor tutor, Pet pet, OwnerType type)
        {
            return new PetOwnership
            {
                Tutor = tutor,
                Pet = pet,
                Type = type
            };
        }

        public bool IsOwner()
        {
            return Type == OwnerType.Owner;
        }
    }

    public enum OwnerType
    {
        Owner,
        Shared,
    }
}