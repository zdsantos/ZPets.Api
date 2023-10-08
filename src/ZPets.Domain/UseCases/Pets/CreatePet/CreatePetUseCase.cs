using AutoMapper;
using ZPets.Domain.Dto;
using ZPets.Domain.Entities.Pets;
using ZPets.Domain.Entities.Tutors;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Pets.CreatePet
{
    public class CreatePetUseCase : GenericUseCaseTemplate<CreatePetRequest, CreatePetValidator, PetDto>, ICreatePetUseCase
    {
        private Pet _newPet;

        public CreatePetUseCase(ApplicationContext appContext, CreatePetValidator validator, IMapper mapper) : base(appContext, validator, mapper)
        {
        }

        protected override Task Process()
        {
            _newPet = Pet.Create(_request.Name, _request.BirthDate, _request.Type, _request.Breed, _request.Gender, _request.Weight);

            PetOwnership petOwnership = PetOwnership.Create(_validator.Tutor, _newPet, OwnerType.Owner);

            _newPet.AddOwnership(petOwnership);
            _validator.Tutor.AddOwnership(petOwnership);

            _appContext.Pets.Add(_newPet);
            _appContext.Tutors.Update(_validator.Tutor);
            _appContext.SaveChanges();

            return Task.CompletedTask;
        }

        protected override PetDto GetResult()
        {
            return _mapper.Map<PetDto>(_newPet);
        }
    }
}
