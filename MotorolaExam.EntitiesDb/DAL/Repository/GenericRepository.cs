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

      public async Task<T> GetSingleAsync(Expression<Func<T, bool>> condition)
         => await _dbSet.Where(condition).FirstOrDefaultAsync();

      public async Task<T> GetSingleWithIncludeAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>> criteria)
         => await _dbSet.Where(condition).Include(criteria).FirstOrDefaultAsync();
   }
}
