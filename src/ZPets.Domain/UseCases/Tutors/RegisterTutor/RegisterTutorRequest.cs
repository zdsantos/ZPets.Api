using ZPets.Domain.Shared.Interfaces;

namespace ZPets.Domain.UseCases.Tutors.RegisterTutor
{
    public class RegisterTutorRequest : IRequest
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}