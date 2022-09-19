using MotorolaExam.Services.Models.DTOs.MotorolaTeam;
using MotorolaExam.Services.Models.DTOs.MotoTechStack;

namespace MotorolaExam.Services.Models.DTOs.MotorolaProject
{
   public class MotorolaProjectReadDto
   {
      public int Id { get; set; }
      public MotorolaTeamReadDto Team { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public MotoTechStackReadDto MotoTechStack { get; set; }
      public DateTime LaunchDate { get; set; }
   }
}
