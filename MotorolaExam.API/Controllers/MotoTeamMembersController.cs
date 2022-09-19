using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MotorolaExam.Services.Models.DTOs.MotoTeamMember;
using MotorolaExam.Services.Services.Interfaces;

namespace MotorolaExam.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class MotoTeamMembersController : ControllerBase
   {
      private readonly IMotoTeamMemberService _motoTeamMemberService;

      public MotoTeamMembersController(IMotoTeamMemberService motoTeamMemberService)
      {
         _motoTeamMemberService = motoTeamMemberService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllMotoTeamMembers()
         => Ok(await _motoTeamMemberService.GetAllAsync());

      [HttpGet("{id}", Name = "GetSingleMotoTeamMember")]
      public async Task<IActionResult> GetSingleMotoTeamMember(int id)
      {
         MotoTeamMemberReadDto teamMember;
         try
         {
            teamMember = await _motoTeamMemberService.GetSingleAsync(mtm => mtm.Id == id);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return Ok(teamMember);
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPost]
      public async Task<IActionResult> CreateNewMotoTeamMember(MotoTeamMemberCreateDto motoTeamMemberCreateDto)
      {
         var newMotoTeamMember = await _motoTeamMemberService.CreateNewAsync(motoTeamMemberCreateDto);
         return Ok(newMotoTeamMember);
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteMotoTeamMember(int id)
      {
         try
         {
            await _motoTeamMemberService.DeleteAsync(mtm => mtm.Id == id);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return NoContent();
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPut("{id}")]
      public async Task<IActionResult> PutMotoTeamMember(int id, MotoTeamMemberUpdateDto motoTeamMemberUpdateDto)
      {
         try
         {
            await _motoTeamMemberService.PutAsync(mtm => mtm.Id == id, motoTeamMemberUpdateDto);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return NoContent();
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPatch("{id}")]
      public async Task<IActionResult> PatchMotoTeamMember(int id, JsonPatchDocument motoTeamMemberPatch)
      {
         try
         {
            await _motoTeamMemberService.PatchAsync(mtm => mtm.Id == id, motoTeamMemberPatch);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return NoContent();
      }
   }
}
