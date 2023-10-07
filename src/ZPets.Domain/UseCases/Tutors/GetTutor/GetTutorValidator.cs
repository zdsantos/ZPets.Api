using Microsoft.AspNetCore.Http;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.GetTutor
{
    public class GetTutorValidator : GenericValidatorTemplate<GetTutorRequest>
    {
        public GetTutorValidator(ApplicationContext appContext, IHttpContextAccessor httpContextAccessor) : base(appContext, httpContextAccessor)
        {
        }

        protected override Task<bool> HasPermissions()
        {
            return Task.FromResult(true);
        }

        protected override Task ValidateData()
        {
            return Task.CompletedTask;
        }

        protected override void ValidateRequest()
        {
            if (string.IsNullOrEmpty(_request.TutorId))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyId);
            }
        }
    }
}
