using ZPets.Domain.Shared.Interfaces;

namespace ZPets.Domain.UseCases.Identity
{
    public class LoginRequest : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
