using Microsoft.AspNetCore.Http;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
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

        protected override Task ValidateData()
        {
            Data.Tutor = _appContext.Tutors.Where(t => t.Email == _request.Email).FirstOrDefault();

            if (Data.Tutor == null)
            {
                _response.SetNotFound(LoginError.Message.EmailNotFound);
            }

            if (!_response.Success())
            {
                return Task.CompletedTask;
            }

            if (!_identityHelper.ComparePassword(_request.Password, Data.Tutor!.Password))
            {
                _response.SetNotFound(LoginError.Message.WrongPassword);
            }

            return Task.CompletedTask;
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
