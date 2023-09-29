using ZPets.Domain.Entities.Pets;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.UseCases.Base;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Pets.CreatePet
{
    public class CreatePetUseCase : BaseUseCase<CreatePetRequest, string>
    {
        private Tutor? _tutor;

        public CreatePetUseCase(ApplicationContext appContext) : base(appContext)
        {
        }

        public override Task Process()
        {
            Pet newPet = Pet.Create(_request.Name, _request.BirthDate, _request.Breed, _request.Gender, _request.Weight);

            PetOwnership petOwnership = PetOwnership.Create(_tutor!, newPet, OwnerType.Owner);

            newPet.AddOwnership(petOwnership);
            _tutor!.AddOwnership(petOwnership);

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
