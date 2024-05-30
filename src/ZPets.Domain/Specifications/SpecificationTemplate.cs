using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using ZPets.Infra.Data;

namespace ZPets.Domain.Specifications
{
    public abstract class SpecificationTemplate<TEntity> where TEntity : class
    {
        protected ApplicationContext _appContext;
        IQueryable<TEntity> _query;

        protected SpecificationTemplate(ApplicationContext appContext)
        {
            _appContext = appContext;

            _query = _appContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _query;
        }

        protected void AddCriteria(Expression<Func<TEntity, bool>> expression)
        {
            _query = _query.Where(expression);
        }

        protected void AddInclude(Expression<Func<TEntity, object>> expression)
        {
            _query = _query.Include(expression);
        }

        protected void SetIncludableQuery(IIncludableQueryable<TEntity, object> includeQuery)
        {
            _query = includeQuery;
        }

        protected void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            _query = _query.OrderBy(orderByExpression);
        }

        protected void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            _query = _query.OrderByDescending(orderByDescendingExpression);
        }

        protected void SetOrderedQuery(IOrderedQueryable<TEntity> orderedQuery)
        {
            _query = orderedQuery;
        }

        protected void ApplyPaging(int skip, int take)
        {
            _query = _query.Skip(skip).Take(take);
        }
    }
}
