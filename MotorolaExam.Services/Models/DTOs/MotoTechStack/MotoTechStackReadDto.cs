using System.ComponentModel.DataAnnotations;

namespace MotorolaExam.Services.Models.DTOs.MotoTechStack
{
   public class MotoTechStackReadDto
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Definition { get; set; }
   }
}
