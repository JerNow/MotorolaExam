using System.Linq.Expressions;

namespace MotorolaExam.EntitiesDb.DAL.Repository
{
   public interface IGenericRepository<T>
   {
      Task AddAsync(T entity);
      Task DeleteAsync(T entity);
      Task EditAsync(T entity);
      Task<List<T>> GetAllAsync();
      Task<List<T>> GetAllWithIncludeAsync(Expression<Func<T, object>> criteria);
      Task<T> GetSingleAsync(Expression<Func<T, bool>> condition);
      Task<T> GetSingleWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria);
   }
}