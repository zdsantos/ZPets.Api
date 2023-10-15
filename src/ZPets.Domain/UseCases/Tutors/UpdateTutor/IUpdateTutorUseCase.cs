using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Interfaces;
using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Tutors.UpdateTutor
{
    public interface IUpdateTutorUseCase : IUseCase<UpdateTutorRequest, UseCaseResponseData<TutorDto>>
    {
    }
}
