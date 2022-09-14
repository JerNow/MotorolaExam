using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.EntitiesDb.Models.Entities
{
   public class Review
   {
      [Key]
      public int Id { get; set; }
      [Required]
      [StringLength(150, ErrorMessage = "No longer than 150 characters")]
      public string Content { get; set; }
   }
}
