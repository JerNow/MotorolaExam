using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.EntitiesDb.Models.Entities
{
   public class MotorolaProject
   {
      [Key]
      public int Id { get; set; }
      public MotorolaTeam Team { get; set; }
      [Required]
      [StringLength(30, MinimumLength = 3, ErrorMessage = "Must be between 3 and 30 characters long")]
      public string Title { get; set; }
      [StringLength(150, ErrorMessage = "No longer than 150 characters")]
      public string Description { get; set; }
      public MotoTechStack MotoTechStack { get; set; }
      public List<Review>? ListOfReviews { get; set; }
      public DateTime LaunchDate { get; set; }

      public MotorolaProject() 
         => ListOfReviews = new List<Review>();
   }
}
