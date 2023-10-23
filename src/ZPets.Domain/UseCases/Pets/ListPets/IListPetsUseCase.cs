using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Interfaces;
using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Pets.ListPets
{
    public interface IListPetsUseCase : IUseCase<ListPetsRequest, UseCaseResponseData<List<PetDto>>>
    {
    }
}
