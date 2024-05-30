using AutoMapper;
using ZPets.Domain.Dto;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Domain.Specifications;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.GetTutor
{
    public class GetTutorUseCase : GenericUseCaseTemplate<GetTutorRequest, GetTutorValidator, TutorDto>, IGetTutorUseCase
    {
        private Tutor? _tutor;

        public GetTutorUseCase(ApplicationContext appContext, GetTutorValidator validator, IMapper mapper) : base(appContext, validator, mapper)
        {
        }

        protected override async Task Process()
        {
            TutorSpecification spec = new(_appContext);
            _tutor = await spec.Get(_request.TutorId);

            if (_tutor == null)
            {
                _response.SetNotFound(TutorsError.Message.NotFound);
            }
        }

        protected override TutorDto GetResult()
        {
            return _mapper.Map<TutorDto>(_tutor);
        }
    }
}
