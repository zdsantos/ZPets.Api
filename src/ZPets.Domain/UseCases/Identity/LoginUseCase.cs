using AutoMapper;
using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;
using ZPets.Infra.Helpers;

namespace ZPets.Domain.UseCases.Identity
{
    public class LoginUseCase : GenericUseCaseTemplate<LoginRequest, LoginValidator, LoginDto>, ILoginUseCase
    {
        private string _token;

        private readonly IdentityHelper _identityHelper;

        public LoginUseCase(ApplicationContext appContext, LoginValidator validator, IdentityHelper identityHelper, IMapper mapper) : base(appContext, validator, mapper)
        {
            _identityHelper = identityHelper;
        }

        protected override LoginDto GetResult()
        {
            return new LoginDto { Token = _token, User = _mapper.Map<TutorDto>(_validator.Data.Tutor!) };
        }

        protected override Task Process()
        {
            _token = _identityHelper.GenerateToken(_validator.Data.Tutor!.Id, _validator.Data.Tutor!.Email);

            return Task.CompletedTask;
        }
    }
}
