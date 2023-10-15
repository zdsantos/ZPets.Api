using Microsoft.AspNetCore.Http;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Pets.CreatePet
{
    public class CreatePetValidator : GenericValidatorTemplate<CreatePetRequest>
    {
        public Tutor Tutor { get; set; }

        public CreatePetValidator(ApplicationContext appContext, IHttpContextAccessor httpContextAccessor) : base(appContext, httpContextAccessor)
        {
        }

        protected override Task<bool> HasPermissions()
        {
            bool hasPermissions = !string.IsNullOrEmpty(_userId) && _userId! == _request.TutorId;
            return Task.FromResult(hasPermissions);
        }

        protected override Task ValidateData()
        {
            Tutor = _appContext.Tutors.Find(_request.TutorId);

            if (Tutor == null)
            {
                _response.SetNotFound(PetsError.Message.NotFound);
            }

            return Task.CompletedTask;
        }

        protected override void ValidateRequest()
        {
            if (string.IsNullOrEmpty(_request.Name))
            {
                _response.SetBadRequest(PetsError.Message.EmptyName);
                return;
            }

            if (string.IsNullOrEmpty(_request.Breed))
            {
                _response.SetBadRequest(PetsError.Message.EmptyBreed);
                return;
            }

            if (_request.Weight <= 0)
            {
                _response.SetBadRequest(PetsError.Message.InvalidWeight);
                return;
            }

            if (_request.BirthDate > DateTime.UtcNow)
            {
                _response.SetBadRequest(PetsError.Message.InvalidBirthDate);
            }
        }
    }
}
