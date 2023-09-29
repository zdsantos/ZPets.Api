using ZPetz.Api.Entities;
using ZPetz.Api.Infra.Data;
using ZPetz.Api.UseCases.Base;

namespace ZPetz.Api.UseCases.Pets.CreatePet
{
    public class CreatePetUseCase : BaseUseCase<CreatePetRequest, string>
    {
        private Tutor? _tutor;

        public CreatePetUseCase(ApplicationContext appContext) : base(appContext)
        {
        }

        public override Task Process()
        {
            Pet newPet = Pet.Create(_tutor, _request.Name, _request.BirthDate, _request.Breed, _request.Gender, _request.Weight);

            _tutor!.Pets.Add(newPet);

            _appContext.Pets.Add(newPet);
            _appContext.Tutors.Update(_tutor);
            _appContext.SaveChanges();

            _response.SetData(newPet.Id.ToString());

            return Task.CompletedTask;
        }

        public override Task Validate()
        {
            ValidateEmptyFields();

            if (!_response.Success())
                return Task.CompletedTask;

            ValidateTutor();

            return Task.CompletedTask;
        }

        private void ValidateEmptyFields()
        {
            if (string.IsNullOrEmpty(_request.Name))
            {
                _response.SetBadRequest("", "Nome do Pet não pode ser vazio");
            }

            if (string.IsNullOrEmpty(_request.TutorId.ToString()))
            {
                _response.SetBadRequest("", "Id do tutor não pode ser vazio");
            }

            if (_request.BirthDate > DateTime.UtcNow)
            {
                _response.SetBadRequest("", "Data de nascimento inválida");
            }

            if (_request.Weight <= 0)
            {
                _response.SetBadRequest("", "Peso inválido");
            }
        }

        private void ValidateTutor()
        {
            _tutor = _appContext.Tutors.Find(_request.TutorId);

            if (_tutor == null)
            {
                _response.SetBadRequest("", "Tutor não encontrado");
            }
        }
    }
}
