using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.Services.Models.DTOs.Authorization
{
   public class UserRegistrationDto
   {

      [Required]
      public string Username { get; set; }
      [Required]
      [EmailAddress]
      public string Email { get; set; }
      [Required]
      public string Password { get; set; }
   }
}
