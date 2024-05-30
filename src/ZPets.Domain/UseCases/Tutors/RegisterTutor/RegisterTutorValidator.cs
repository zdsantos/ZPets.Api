using Microsoft.AspNetCore.Http;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Helpers;
using ZPets.Domain.Shared.Templates;
using ZPets.Domain.Specifications;
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
            if (string.IsNullOrWhiteSpace(_request.Name))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyName);
                return;
            }

            if (string.IsNullOrWhiteSpace(_request.Password))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyPassword);
                return;
            }

            if (string.IsNullOrWhiteSpace(_request.Email))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyEmail);
            }
        }

        protected override async Task ValidateData()
        {
            TutorSpecification spec = new(_appContext);
            Tutor? tutorFound = await spec.GetByEmail(_request.Email);

            if (tutorFound != null)
            {
                _response.SetBadRequest(TutorsError.Message.EmailAlreadInUse);
            }

            if (!ValidatorsHelper.ValidatePassword(_request.Password))
            {
                _response.SetBadRequest(TutorsError.Message.WrongPatternPassword);
            }
        }
    }
}