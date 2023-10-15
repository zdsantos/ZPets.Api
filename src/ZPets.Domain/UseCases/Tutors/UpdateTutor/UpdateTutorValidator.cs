using Microsoft.AspNetCore.Http;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.UpdateTutor
{
    public class UpdateTutorValidator : GenericValidatorTemplate<UpdateTutorRequest>
    {
        public OutputData Data { get; set; } = new();

        public class OutputData
        {
            public Tutor? Tutor { get; set; }
        }

        public UpdateTutorValidator(ApplicationContext appContext, IHttpContextAccessor httpContextAccessor) : base(appContext, httpContextAccessor)
        {
        }

        protected override Task<bool> HasPermissions()
        {
            bool hasPermissions = !string.IsNullOrEmpty(_userId) && _userId! == _request.TutorId;
            return Task.FromResult(hasPermissions);
        }

        protected override Task ValidateData()
        {
            Data.Tutor = _appContext.Tutors.Find(_request.TutorId);

            if (Data.Tutor == null)
            {
                _response.SetBadRequest(TutorsError.Message.NotFound);
                return Task.CompletedTask;
            }

            Tutor? tutor = _appContext.Tutors.Where(t => t.Email == _request.Email).FirstOrDefault();

            if (tutor != null && tutor.Id != _request.TutorId)
            {
                _response.SetBadRequest(TutorsError.Message.EmailAlreadInUse);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        protected override void ValidateRequest()
        {
            if (string.IsNullOrWhiteSpace(_request.Name))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyName);
                return;
            }

            if (string.IsNullOrWhiteSpace(_request.Email))
            {
                _response.SetBadRequest(TutorsError.Message.EmptyEmail);
            }
        }
    }
}
