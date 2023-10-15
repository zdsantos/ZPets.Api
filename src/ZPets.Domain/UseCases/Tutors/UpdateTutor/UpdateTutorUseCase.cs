using AutoMapper;
using ZPets.Domain.Dto;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.UpdateTutor
{
    public class UpdateTutorUseCase : GenericUseCaseTemplate<UpdateTutorRequest, UpdateTutorValidator, TutorDto>, IUpdateTutorUseCase
    {
        private Tutor _tutor;

        public UpdateTutorUseCase(ApplicationContext appContext, UpdateTutorValidator validator, IMapper mapper) : base(appContext, validator, mapper)
        {
        }

        protected override Task Process()
        {
            _tutor = _validator.Data.Tutor!;

            _tutor.Update(_request.Name!, _request.Email!);

            _appContext.Tutors.Update(_tutor);
            _appContext.SaveChanges();

            return Task.CompletedTask;
        }

        protected override TutorDto GetResult()
        {
            return _mapper.Map<TutorDto>(_tutor);
        }
    }
}
