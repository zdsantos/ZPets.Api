using AutoMapper;
using ZPets.Domain.Dto;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;
using ZPets.Infra.Helpers;

namespace ZPets.Domain.UseCases.Tutors.RegisterTutor
{
    public class RegisterTutorUseCase : GenericUseCaseTemplate<RegisterTutorRequest, RegisterTutorValidator, TutorDto>, IRegisterTutorUseCase
    {
        private Tutor _tutor;
        private readonly IdentityHelper _identityHelper;

        public RegisterTutorUseCase(ApplicationContext appContext, RegisterTutorValidator validator, IdentityHelper identityHelper, IMapper mapper) : base(appContext, validator, mapper)
        {
            _identityHelper = identityHelper;
        }

        protected override Task Process()
        {
            Tutor newTutor = new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = _request.Email,
                Name = _request.Name,
                Password = _identityHelper.Encrypt(_request.Password),
            };

            _appContext.Tutors.Add(newTutor);
            _appContext.SaveChanges();

            _tutor = newTutor;

            return Task.CompletedTask;
        }

        protected override TutorDto GetResult()
        {
            return _mapper.Map<TutorDto>(_tutor);
        }
    }
}
