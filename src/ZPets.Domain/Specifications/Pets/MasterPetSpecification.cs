using Microsoft.EntityFrameworkCore;
using ZPets.Domain.Entities.Pets;
using ZPets.Infra.Data;

namespace ZPets.Domain.Specifications.Pets
{
    //Just an example
    public class MasterPetSpecification : PetSpecificationTemplate
    {
        public MasterPetSpecification(ApplicationContext appContext, bool includeOwners) : base(appContext)
        {
            if (includeOwners)
            {
                AddInclude(p => p.PetOwners);
            }
        }

        public Task<List<Pet>> ListByBreed(Breed breed)
        {
            AddCriteria(p => p.Breed == breed.Name);
            return GetQuery().ToListAsync();
        }
    }
}
