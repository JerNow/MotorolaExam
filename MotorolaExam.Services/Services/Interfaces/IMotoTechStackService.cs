using Microsoft.AspNetCore.JsonPatch;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotoTechStack;
using System.Linq.Expressions;

namespace MotorolaExam.Services.Services.Interfaces
{
   public interface IMotoTechStackService
   {
      Task<MotoTechStackReadDto> CreateNewAsync(MotoTechStackCreateDto motoTechStackCreateDto);
      Task<List<MotoTechStackReadDto>> GetAllAsync();
      Task<MotoTechStackReadDto> GetSingleAsync(Expression<Func<MotoTechStack, bool>> condition);
      Task PatchAsync(Expression<Func<MotoTechStack, bool>> condition, JsonPatchDocument motoTechStackPatch);
      Task PutAsync(Expression<Func<MotoTechStack, bool>> condition, MotoTechStackUpdateDto motoTechStackUpdateDto);

   }
}
