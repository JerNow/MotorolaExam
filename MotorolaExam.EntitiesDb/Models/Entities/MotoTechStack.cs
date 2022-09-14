using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.EntitiesDb.Models.Entities
{
   public class MotoTechStack
   {
      [Key]
      public int Id { get; set; }
      [Required]
      [StringLength(30, MinimumLength = 3, ErrorMessage = "Must be between 3 and 30 characters long")]
      public string Name { get; set; }
      [StringLength(150, ErrorMessage = "No longer than 150 characters")]
      public string Definition { get; set; }
   }
}
