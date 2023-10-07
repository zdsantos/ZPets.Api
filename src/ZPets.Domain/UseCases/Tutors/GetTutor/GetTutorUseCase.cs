using AutoMapper;
using ZPets.Domain.Dto;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.GetTutor
{
    public class GetTutorUseCase : GenericUseCaseTemplate<GetTutorRequest, GetTutorValidator, TutorDto>, IGetTutorUseCase
    {
        private Tutor? _tutor;

        public GetTutorUseCase(ApplicationContext appContext, GetTutorValidator validator, IMapper mapper) : base(appContext, validator, mapper)
        {
        }

        protected override Task Process()
        {
            _tutor = _appContext.Tutors.Find(_request.TutorId);

            if (_tutor == null)
            {
                _response.SetNotFound(TutorsError.Message.NotFound);
            }

            return Task.CompletedTask;
        }

        protected override TutorDto GetResult()
        {
            return _mapper.Map<TutorDto>(_tutor);
        }
    }
}
