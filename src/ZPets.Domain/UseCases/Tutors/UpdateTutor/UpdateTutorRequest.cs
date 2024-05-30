using ZPets.Domain.Shared.Interfaces;

namespace ZPets.Domain.UseCases.Tutors.UpdateTutor
{
    public class UpdateTutorRequest : IRequest
    {
        public string TutorId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
