using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZPets.Domain.Dto;
using ZPets.Domain.Entities.Pets;
using ZPets.Domain.Shared.Templates;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Pets.ListPets
{
    public class ListPetsUseCase : GenericUseCaseTemplate<ListPetsRequest, ListPetsValidator, List<PetDto>>, IListPetsUseCase
    {
        private List<Pet> _pets;

        public ListPetsUseCase(ApplicationContext appContext, ListPetsValidator validator, IMapper mapper) : base(appContext, validator, mapper)
        {
        }

        protected override async Task Process()
        {
            var tutor = await _appContext.Tutors
                .Include(t => t.Pets)
                .ThenInclude(po => po.Pet).AsSplitQuery()
                .FirstAsync(t => t.Id == _request.TutorId);

            _pets = tutor.Pets.Select(po => po.Pet).ToList();
        }

        protected override List<PetDto> GetResult()
        {
            return _pets.Select(p => _mapper.Map<PetDto>(p)).ToList();
        }
    }
}
