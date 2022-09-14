using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.Services.Models.DTOs.Authorization
{
   public class UserLoginRequestDto
   {

      [Required]
      [EmailAddress]
      public string Email { get; set; }
      [Required]
      public string Password { get; set; }
   }
}
