using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Interfaces;
using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Pets.CreatePet
{
    public interface ICreatePetUseCase : IUseCase<CreatePetRequest, UseCaseResponseData<PetDto>>
    {
    }
}
