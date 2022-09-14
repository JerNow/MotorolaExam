using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.EntitiesDb.Models.Entities
{
   public class MotorolaTeam
   {
      [Key]
      public int Id { get; set; }
      [Required]
      [StringLength(30, MinimumLength = 3, ErrorMessage = "Must be between 3 and 30 characters long")]
      public string Name { get; set; }
      public List<MotoTeamMember> MotoTeamMembers { get; set; }

      public MotorolaTeam() 
         => MotoTeamMembers = new List<MotoTeamMember>();
   }
}
