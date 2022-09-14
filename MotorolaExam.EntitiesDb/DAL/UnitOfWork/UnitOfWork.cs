using MotorolaExam.EntitiesDb.Context;
using MotorolaExam.EntitiesDb.DAL.Repository;
using MotorolaExam.EntitiesDb.Models.Entities;

namespace MotorolaExam.EntitiesDb.DAL.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly MotorolaExamEntitiesDbContext _motorolaExamEntitiesDbContext;
      public IGenericRepository<MotorolaProject> MotorolaProjects { get; }
      public IGenericRepository<MotorolaTeam> MotorolaTeams { get; }
      public IGenericRepository<MotoTeamMember> MotoTeamMembers { get; }
      public IGenericRepository<MotoTechStack> MotoTechStacks { get; }

      public UnitOfWork(MotorolaExamEntitiesDbContext motorolaExamEntitiesDbContext)
      {
         _motorolaExamEntitiesDbContext = motorolaExamEntitiesDbContext;
         MotorolaProjects = new GenericRepository<MotorolaProject>(_motorolaExamEntitiesDbContext);
         MotorolaTeams = new GenericRepository<MotorolaTeam>(_motorolaExamEntitiesDbContext);
         MotoTeamMembers = new GenericRepository<MotoTeamMember>(_motorolaExamEntitiesDbContext);
         MotoTechStacks = new GenericRepository<MotoTechStack>(_motorolaExamEntitiesDbContext);
      }

      public async Task<int> CompleteUnitOfWorkAsync()
         => await _motorolaExamEntitiesDbContext.SaveChangesAsync();
   }
}
