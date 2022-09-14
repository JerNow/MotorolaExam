using Microsoft.EntityFrameworkCore;
using MotorolaExam.EntitiesDb.Models.Entities;

namespace MotorolaExam.EntitiesDb.Context
{
   public class MotorolaExamEntitiesDbContext : DbContext
   {
      public DbSet<MotorolaProject> MotorolaProjects { get; set; }
      public DbSet<MotorolaTeam> MotorolaTeams { get; set; }
      public DbSet<MotoTeamMember> MotoTeamMembers { get; set; }
      public DbSet<MotoTechStack> MotoTechStacks { get; set; }

      public MotorolaExamEntitiesDbContext(DbContextOptions<MotorolaExamEntitiesDbContext> options) : base(options)
      {
      }


   }
}
