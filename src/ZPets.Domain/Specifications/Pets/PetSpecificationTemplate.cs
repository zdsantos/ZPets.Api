using ZPets.Domain.Entities.Pets;
using ZPets.Infra.Data;

namespace ZPets.Domain.Specifications.Pets
{
    public abstract class PetSpecificationTemplate : SpecificationTemplate<Pet>
    {
        protected PetSpecificationTemplate(ApplicationContext appContext) : base(appContext)
        {
            AddInclude(p => p.Vaccines);
            AddInclude(p => p.Weights);
        }
    }
}
