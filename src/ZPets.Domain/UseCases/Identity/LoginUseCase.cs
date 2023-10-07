using AutoMapper;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;
using ZPets.Infra.Helpers;

namespace ZPets.Domain.UseCases.Identity
{
    public class LoginUseCase : GenericUseCaseTemplate<LoginRequest, LoginValidator, string>, ILoginUseCase
    {
        private string _token;

        private readonly IdentityHelper _identityHelper;

        public LoginUseCase(ApplicationContext appContext, LoginValidator validator, IdentityHelper identityHelper, IMapper mapper) : base(appContext, validator, mapper)
        {
            _identityHelper = identityHelper;
        }

        protected override string GetResult()
        {
            return _token;
        }

        protected override Task Process()
        {
            _token = _identityHelper.GenerateToken(_validator.Tutor.Id, _validator.Tutor.Email);

            return Task.CompletedTask;
        }
    }
}
