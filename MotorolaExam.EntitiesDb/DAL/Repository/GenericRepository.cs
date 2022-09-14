using Microsoft.EntityFrameworkCore;
using MotorolaExam.EntitiesDb.Context;
using System.Linq.Expressions;

namespace MotorolaExam.EntitiesDb.DAL.Repository
{
   public class GenericRepository<T> : IGenericRepository<T> where T : class
   {
      private MotorolaExamEntitiesDbContext _motorolaExamEntitiesDbContext;
      private DbSet<T> _dbSet;

      public GenericRepository(MotorolaExamEntitiesDbContext motorolaExamEntitiesDbContext)
      {
         _motorolaExamEntitiesDbContext = motorolaExamEntitiesDbContext;
         _dbSet = _motorolaExamEntitiesDbContext.Set<T>();
      }

      public async Task AddAsync(T entity)
      {
         await _dbSet.AddAsync(entity);
         await _motorolaExamEntitiesDbContext.SaveChangesAsync();
      }

      public async Task DeleteAsync(T entity)
      {
         _dbSet.Remove(entity);
         await _motorolaExamEntitiesDbContext.SaveChangesAsync();
      }

      public async Task EditAsync(T entity)
      {
         _dbSet.Attach(entity);
         _motorolaExamEntitiesDbContext.Entry(entity).State = EntityState.Modified;
         await _motorolaExamEntitiesDbContext.SaveChangesAsync();
      }

      public async Task<List<T>> GetAllAsync()
         => await _dbSet.ToListAsync();

      public async Task<List<T>> GetAllWithIncludeAsync(Expression<Func<T, object>> criteria)
         => await _dbSet.Include(criteria).ToListAsync();

      public async Task<List<T>> GetAllWithIncludeAndIncludeAsync(
         Expression<Func<T, object>> criteriaIncludeFirst,
         Expression<Func<T, object>> criteriaIncludeSecond)
            => await _dbSet.Include(criteriaIncludeFirst)
                           .Include(criteriaIncludeSecond)
                           .ToListAsync();

      public async Task<List<T>> GetAllWithIncludeAndIncludeAndIncludeAsync(
         Expression<Func<T, object>> criteriaIncludeFirst,
         Expression<Func<T, object>> criteriaIncludeSecond,
         Expression<Func<T, object>> criteriaIncludeThird)
            => await _dbSet.Include(criteriaIncludeFirst)
                           .Include(criteriaIncludeSecond)
                           .Include(criteriaIncludeThird)
                           .ToListAsync();

      public async Task<T> GetSingleAsync(Expression<Func<T, bool>> condition)
         => await _dbSet.Where(condition).FirstOrDefaultAsync();

      public async Task<T> GetSingleWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria)
         => await _dbSet.Where(condition).Include(criteria).FirstOrDefaultAsync();

      public async Task<T> GetSingleWithIncludeAndIncludeAsync(
         Expression<Func<T, bool>> condition,
         Expression<Func<T, object>> criteriaIncludeFirst,
         Expression<Func<T, object>> criteriaIncludeSecond)
            => await _dbSet.Where(condition)
                           .Include(criteriaIncludeFirst)
                           .Include(criteriaIncludeSecond)
                           .FirstOrDefaultAsync();

      public async Task<T> GetSingleWithIncludeAndIncludeAndIncludeAsync(
         Expression<Func<T, bool>> condition,
         Expression<Func<T, object>> criteriaIncludeFirst,
         Expression<Func<T, object>> criteriaIncludeSecond,
         Expression<Func<T, object>> criteriaIncludeThird)
            => await _dbSet.Where(condition)
                           .Include(criteriaIncludeFirst)
                           .Include(criteriaIncludeSecond)
                           .Include(criteriaIncludeThird)
                          .FirstOrDefaultAsync();

      public async Task<List<T>> GetAllWithConditionAndWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria)
         => await _dbSet.Where(condition).Include(criteria).ToListAsync();
   }
}
