using Microsoft.AspNetCore.JsonPatch;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotorolaProject;
using System.Linq.Expressions;

namespace MotorolaExam.Services.Services.Interfaces
{
   public interface IMotorolaProjectService
   {
      Task<MotorolaProjectReadDto> CreateNewAsync(MotorolaProjectCreateDto motorolaProjectCreateDto);
      Task DeleteAsync(Expression<Func<MotorolaProject, bool>> condition);
      Task<List<MotorolaProjectReadDto>> GetAllAsync();
      Task<MotorolaProjectReadDto> GetSingleAsync(Expression<Func<MotorolaProject, bool>> condition);
      Task PatchAsync(Expression<Func<MotorolaProject, bool>> condition, JsonPatchDocument motorolaProjectPatch);
      Task PutAsync(Expression<Func<MotorolaProject, bool>> condition, MotorolaProjectUpdateDto motorolaProjectUpdateDto);
   }
}
