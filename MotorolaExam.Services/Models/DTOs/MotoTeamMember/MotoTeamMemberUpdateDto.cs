using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.Services.Models.DTOs.MotoTeamMember
{
   public class MotoTeamMemberUpdateDto
   {
      [Required]
      [StringLength(30, MinimumLength = 3, ErrorMessage = "Must be between 3 and 30 characters long")]
      public string Name { get; set; }
      [Required]
      [Range(0, 100, ErrorMessage = "Must be between 0-100")]
      public int YearsOfExpierience { get; set; }
      [Required]
      [StringLength(30, MinimumLength = 3, ErrorMessage = "Must be between 3 and 30 characters long")]
      public string Specialization { get; set; }
   }
}
