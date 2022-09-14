using Microsoft.AspNetCore.JsonPatch;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotoTeamMember;
using System.Linq.Expressions;

namespace MotorolaExam.Services.Services.Interfaces
{
   public interface IMotoTeamMemberService
   {
      Task<MotoTeamMemberReadDto> CreateNewAsync(MotoTeamMemberCreateDto motoTeamMemberCreateDto);
      Task DeleteAsync(Expression<Func<MotoTeamMember, bool>> condition);
      Task<List<MotoTeamMemberReadDto>> GetAllAsync();
      Task<MotoTeamMemberReadDto> GetSingleAsync(Expression<Func<MotoTeamMember, bool>> condition);
      Task PatchAsync(Expression<Func<MotoTeamMember, bool>> condition, JsonPatchDocument motoTeamMemberPatch);
      Task PutAsync(Expression<Func<MotoTeamMember, bool>> condition, MotoTeamMemberUpdateDto motoTeamMemberUpdateDto);
   }
}
