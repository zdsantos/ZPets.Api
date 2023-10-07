using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Interfaces;
using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Tutors.GetTutor
{
    public interface IGetTutorUseCase : IUseCase<GetTutorRequest, UseCaseResponseData<TutorDto>>
    {
    }
}
