using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorolaExam.Services.Services.Interfaces;

namespace MotorolaExam.API.Controllers
{
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
   [Route("api/[controller]")]
   [ApiController]
   public class MotorolaTeamsController : ControllerBase
   {
      private readonly IMotorolaTeamService _motorolaTeamService;

      public MotorolaTeamsController(IMotorolaTeamService motorolaTeamService)
      {
         _motorolaTeamService = motorolaTeamService;
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetAverageYears(int id)
      {
         float averageYears;
         try
         {
            averageYears = await _motorolaTeamService.GetTeamAverageYearsAsync(id);
         }
         catch (ArgumentNullException e)
         {
            return NotFound();
         }
         return Ok(averageYears);
      }
   }
}
