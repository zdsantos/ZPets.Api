using Microsoft.AspNetCore.Http;
using ZPets.Domain.Helpers;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.RegisterTutor
{
    public class RegisterTutorValidator : GenericValidatorTemplate<RegisterTutorRequest>
    {
        public RegisterTutorValidator(ApplicationContext appContext, IHttpContextAccessor httpContextAccessor) : base(appContext, httpContextAccessor)
        {
        }

        protected override Task<bool> HasPermissions()
        {
            return Task.FromResult(true);
        }

        protected override void ValidateRequest()
        {
            if (string.IsNullOrEmpty(_request.Name))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyName);
                return;
            }

            if (string.IsNullOrEmpty(_request.Password))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyPassword);
                return;
            }

            if (string.IsNullOrEmpty(_request.Email))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyEmail);
            }
        }

        protected override Task ValidateData()
        {
            bool emailAlreadyInUse = _appContext.Tutors.Where(t => t.Email == _request.Email).Any();

            if (emailAlreadyInUse)
            {
                _response.SetBadRequest(TutorsError.Message.EmailAlreadInUse);
                return Task.CompletedTask;
            }

            if (!ValidatorsHelper.ValidatePassword(_request.Password))
            {
                _response.SetBadRequest(TutorsError.Message.WrongPatternPassword);
            }

            return Task.CompletedTask;
        }
    }
}