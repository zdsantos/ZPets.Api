using Microsoft.AspNetCore.Http;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Pets.ListPets
{
    public class ListPetsValidator : GenericValidatorTemplate<ListPetsRequest>
    {
        public ListPetsValidator(ApplicationContext appContext, IHttpContextAccessor httpContextAccessor) : base(appContext, httpContextAccessor)
        {
        }

        protected override Task<bool> HasPermissions()
        {
            bool hasPermissions = !string.IsNullOrEmpty(_userId) && _userId! == _request.TutorId;
            return Task.FromResult(hasPermissions);
        }

        protected override Task ValidateData()
        {
            Tutor? tutor = _appContext.Tutors.Find(_request.TutorId);

            if (tutor == null)
            {
                _response.SetBadRequest(PetsError.Message.TutorNotFound);
            }

            return Task.CompletedTask;
        }

        protected override void ValidateRequest()
        {
        }
    }
}
