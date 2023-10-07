using ZPets.Domain.Shared.Interfaces;

namespace ZPets.Domain.UseCases.Tutors.GetTutor
{
    public class GetTutorRequest : IRequest
    {
        public string TutorId { get; set; }
    }
}