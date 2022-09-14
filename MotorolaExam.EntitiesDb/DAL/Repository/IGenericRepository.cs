using System.Linq.Expressions;

namespace MotorolaExam.EntitiesDb.DAL.Repository
{
   public interface IGenericRepository<T>
   {
      Task AddAsync(T entity);
      Task DeleteAsync(T entity);
      Task EditAsync(T entity);
      Task<List<T>> GetAllAsync();
      Task<List<T>> GetAllWithConditionAndWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria);
      Task<List<T>> GetAllWithIncludeAndIncludeAndIncludeAsync(Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond, Expression<Func<T, object>> criteriaIncludeThird);
      Task<List<T>> GetAllWithIncludeAndIncludeAsync(Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond);
      Task<List<T>> GetAllWithIncludeAsync(Expression<Func<T, object>> criteria);
      Task<T> GetSingleAsync(Expression<Func<T, bool>> condition);
      Task<T> GetSingleWithIncludeAndIncludeAndIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond, Expression<Func<T, object>> criteriaIncludeThird);
      Task<T> GetSingleWithIncludeAndIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteriaIncludeFirst, Expression<Func<T, object>> criteriaIncludeSecond);
      Task<T> GetSingleWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria);
   }
}