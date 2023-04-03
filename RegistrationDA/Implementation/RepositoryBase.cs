using Microsoft.EntityFrameworkCore;
using Registration.DataAccess.Interface;
using RegistrationDA.Entities;
using System.Linq.Expressions;

namespace Registration.DataAccess.Implementation
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryDBContext _repositoryDBContext;

        public RepositoryBase(RepositoryDBContext repositoryDBContext)
        {
            _repositoryDBContext = repositoryDBContext;
            _repositoryDBContext.Database.EnsureCreated();
        }

        public async Task<IEnumerable<T>> GetAllEntities() => await _repositoryDBContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
             _repositoryDBContext.Set<T>().Where(expression);

        public async Task<bool> CreateEntity(T entity)
        {
            var result = _repositoryDBContext.Set<T>().Add(entity);
            return result.State == EntityState.Added ? true : false;
        }

        public async Task<bool> UpdateEntity(T entity)
        {
            var result = _repositoryDBContext.Set<T>().Add(entity);
            return result.State == EntityState.Modified ? true : false;
        }

        public async Task<bool> DeleteEntity(int id)
        {
            var entity = await FindByCondition(_ => _.Equals(id));
            var result = _repositoryDBContext.Set<T>().Remove(entity.First());
            return result.State == EntityState.Deleted ? true : false;
        }
    }
}
