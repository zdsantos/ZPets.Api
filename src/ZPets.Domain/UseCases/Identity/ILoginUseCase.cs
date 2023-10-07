using ZPets.Domain.Shared.Interfaces;
using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Identity
{
    public interface ILoginUseCase : IUseCase<LoginRequest, UseCaseResponseData<string>>
    {
    }
}
