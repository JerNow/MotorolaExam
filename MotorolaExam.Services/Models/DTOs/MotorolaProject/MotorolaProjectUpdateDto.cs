using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.Services.Models.DTOs.MotorolaProject
{
   public class MotorolaProjectUpdateDto
   {
      public int TeamId { get; set; }
      [Required]
      [StringLength(30, MinimumLength = 3, ErrorMessage = "Must be between 3 and 30 characters long")]
      public string Title { get; set; }
      [StringLength(150, ErrorMessage = "No longer than 150 characters")]
      public string Description { get; set; }
      public int MotoTechStackId { get; set; }
      public DateTime LaunchDate { get; set; }
   }
}
