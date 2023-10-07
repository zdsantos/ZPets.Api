using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Interfaces;
using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Tutors.RegisterTutor
{
    public interface IRegisterTutorUseCase : IUseCase<RegisterTutorRequest, UseCaseResponseData<TutorDto>>
    {
    }
}