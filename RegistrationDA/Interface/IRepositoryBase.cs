using System.Linq.Expressions;

namespace Registration.DataAccess.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllEntities();

        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> condition);

        Task<bool> CreateEntity(T entity);

        Task<bool> UpdateEntity(T entity);

        Task<bool> DeleteEntity(int id);
    }
}
