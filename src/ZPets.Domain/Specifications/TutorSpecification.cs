using Microsoft.EntityFrameworkCore;
using ZPets.Domain.Entities.Tutors;
using ZPets.Infra.Data;

namespace ZPets.Domain.Specifications
{
    public class TutorSpecification : SpecificationTemplate<Tutor>
    {
        public TutorSpecification(ApplicationContext appContext) : base(appContext)
        {
        }

        public Task<Tutor?> Get(string tutorId)
        {
            AddCriteria(Tutor.Expression.Criteria.Id(tutorId));

            return GetQuery().FirstOrDefaultAsync();
        }

        public Task<Tutor?> GetByEmail(string email)
        {
            AddCriteria(Tutor.Expression.Criteria.Email(email));

            return GetQuery().FirstOrDefaultAsync();
        }
    }
}
