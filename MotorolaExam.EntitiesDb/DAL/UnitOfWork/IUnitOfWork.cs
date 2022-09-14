using MotorolaExam.EntitiesDb.DAL.Repository;
using MotorolaExam.EntitiesDb.Models.Entities;

namespace MotorolaExam.EntitiesDb.DAL.UnitOfWork
{
   public interface IUnitOfWork
   {
      IGenericRepository<MotorolaProject> MotorolaProjects { get; }
      IGenericRepository<MotorolaTeam> MotorolaTeams { get; }
      IGenericRepository<MotoTeamMember> MotoTeamMembers { get; }
      IGenericRepository<MotoTechStack> MotoTechStacks { get; }

      Task<int> CompleteUnitOfWorkAsync();
   }
}