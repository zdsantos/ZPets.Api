using Microsoft.AspNetCore.Http;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Domain.Specifications;
using ZPets.Infra.Data;
using ZPets.Infra.Helpers;

namespace ZPets.Domain.UseCases.Identity
{
    public class LoginValidator : GenericValidatorTemplate<LoginRequest>
    {
        private readonly IdentityHelper _identityHelper;

        public OutputData Data { get; private set; } = new();

        public class OutputData
        {
            public Tutor? Tutor { get; set; }
        }

        public LoginValidator(ApplicationContext appContext, IdentityHelper identityHelper, IHttpContextAccessor httpContextAccessor) : base(appContext, httpContextAccessor)
        {
            _identityHelper = identityHelper;
        }

        protected override Task<bool> HasPermissions()
        {
            return Task.FromResult(true);
        }

        protected override async Task ValidateData()
        {
            TutorSpecification spec = new(_appContext);
            Data.Tutor = await spec.GetByEmail(_request.Email);

            if (Data.Tutor == null)
            {
                _response.SetNotFound(LoginError.Message.EmailNotFound);
                return;
            }

            if (!_identityHelper.ComparePassword(_request.Password, Data.Tutor.Password))
            {
                _response.SetNotFound(LoginError.Message.WrongPassword);
            }
        }

        protected override void ValidateRequest()
        {
            if (string.IsNullOrEmpty(_request.Email))
            {
                _response.SetBadRequest(LoginError.Message.EmptyEmail);
                return;
            }

            if (string.IsNullOrEmpty(_request.Password))
            {
                _response.SetBadRequest(LoginError.Message.EmptyPassword);
            }
        }
    }
}
