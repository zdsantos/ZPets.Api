using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.UseCases.Base;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.GetTutor
{
    public class GetTutorUseCase : BaseUseCase<GetTutorRequest, Tutor>
    {
        private Tutor? _tutor;

        public GetTutorUseCase(ApplicationContext appContext) : base(appContext)
        {
        }

        public override Task Process()
        {
            _response.SetData(_tutor!);

            return Task.CompletedTask;
        }

        public override Task Validate()
        {
            _tutor = _appContext.Tutors.Find(_request.TutorId);

            if ( _tutor == null )
            {
                _response.SetNotFound("", $"Tutor {_request.TutorId} não encontrado");
            }

            return Task.CompletedTask;
        }
    }
}
