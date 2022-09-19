using MotorolaExam.EntitiesDb.Models.Entities;
using System.Linq.Expressions;

namespace MotorolaExam.EntitiesDb.DAL.Repository
{
   public interface IMotorolaProjectRepository : IGenericRepository<MotorolaProject>
   {
      Task<List<MotorolaProject>> GetAllMotorolaProjectsAsync();
      Task<MotorolaProject> GetSingleMotorolaProjectAsync(Expression<Func<MotorolaProject, bool>> condition);
   }
}
