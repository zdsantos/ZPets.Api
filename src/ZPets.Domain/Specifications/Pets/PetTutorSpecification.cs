using Microsoft.EntityFrameworkCore;
using ZPets.Domain.Entities.Pets;
using ZPets.Infra.Data;

namespace ZPets.Domain.Specifications.Pets
{
    internal class PetTutorSpecification : PetSpecificationTemplate
    {
        public PetTutorSpecification(ApplicationContext appContext, string tutorId, bool onlyOwned = false) : base(appContext)
        {
            AddInclude(p => p.PetOwners);

            AddCriteria(Pet.Expression.Criteria.Tutor(tutorId, onlyOwned));
        }

        public Task<Pet?> Get(string petId)
        {
            AddCriteria(Pet.Expression.Criteria.Id(petId));

            return GetQuery().FirstOrDefaultAsync();
        }

        public Task<List<Pet>> List()
        {
            return GetQuery().ToListAsync();
        }
    }
}
