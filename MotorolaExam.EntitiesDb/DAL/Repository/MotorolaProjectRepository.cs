using Microsoft.EntityFrameworkCore;
using MotorolaExam.EntitiesDb.Context;
using MotorolaExam.EntitiesDb.Models.Entities;
using System.Linq.Expressions;

namespace MotorolaExam.EntitiesDb.DAL.Repository
{
   public class MotorolaProjectRepository : GenericRepository<MotorolaProject>, IMotorolaProjectRepository
   {
      private MotorolaExamEntitiesDbContext _motorolaExamEntitiesDbContext;
      private DbSet<MotorolaProject> _dbSet;
      public MotorolaProjectRepository(MotorolaExamEntitiesDbContext motorolaExamEntitiesDbContext) : base(motorolaExamEntitiesDbContext)
      {
         _motorolaExamEntitiesDbContext = motorolaExamEntitiesDbContext;
         _dbSet = _motorolaExamEntitiesDbContext.Set<MotorolaProject>();
      }

      public async Task<List<MotorolaProject>> GetAllMotorolaProjectsAsync()
         => await _dbSet.Include(mp => mp.Team)
                           .Include(mp => mp.MotoTechStack)
                           .ToListAsync();

      public async Task<MotorolaProject> GetSingleMotorolaProjectAsync(Expression<Func<MotorolaProject, bool>> condition)
         => await _dbSet.Where(condition)
                           .Include(mp => mp.Team)
                           .Include(mp => mp.MotoTechStack)
                           .FirstOrDefaultAsync();
   }
}
