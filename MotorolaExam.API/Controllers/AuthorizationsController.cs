using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorolaExam.Services.Models.DTOs.Authorization;
using MotorolaExam.Services.Services.Interfaces;

namespace MotorolaExam.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthorizationsController : ControllerBase
   {
      private readonly IMyAuthorizationService _authorizationService;

      public AuthorizationsController(IMyAuthorizationService authorizationService)
      {
         _authorizationService = authorizationService;
      }

      [HttpPost]
      [Route("Register")]
      public async Task<IActionResult> Register(UserRegistrationDto userRegistrationDto)
      {
         var checkResult = await _authorizationService.DoesUserExistAsync(userRegistrationDto);
         if (checkResult == true)
            return BadRequest("User with that email already exist");
         MotorolaExam.Services.Models.AuthorizationResult registerResult;
         try
         {
            registerResult = await _authorizationService.RegisterNewUser(userRegistrationDto);
         } 
         catch(Exception e)
         {
            return StatusCode(500);
         }
         if (!registerResult.Success)
            return BadRequest(registerResult.Message);
         return Ok(registerResult);
      }

      [HttpPost]
      [Route("Login")]
      public async Task<IActionResult> Login(UserLoginRequestDto userLoginRequest)
      {
         var userFromDb = await _authorizationService.DoesUserExistAsync(userLoginRequest);
         if (userFromDb == null)
            return BadRequest("Invalid creditentials"); //no user in Db found

         var loginResult = await _authorizationService.LoginUser(userLoginRequest, userFromDb);
         if (!loginResult.Success)
            return BadRequest("Invalid creditentials"); //password mismatch

         return Ok(loginResult.Message);
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPost]
      [Route("RegisterAdmin")]
      public async Task<IActionResult> RegisterAdmin(UserRegistrationDto userRegistrationDto)
      {
         var checkResult = await _authorizationService.DoesUserExistAsync(userRegistrationDto);
         if (checkResult == true)
            return BadRequest("User with that email already exist");
         MotorolaExam.Services.Models.AuthorizationResult registerResult;
         try
         {
            registerResult = await _authorizationService.RegisterNewUser(userRegistrationDto);
         }
         catch (Exception e)
         {
            return StatusCode(500);
         }
         if (!registerResult.Success)
            return BadRequest(registerResult.Message);
         var roleAdditionResult = false;
         try
         {
            roleAdditionResult = await _authorizationService.AddAdminRole(userRegistrationDto);
         } 
         catch (Exception e)
         {
            StatusCode(500);
         }
         if (roleAdditionResult)
            return Ok(registerResult.Message);
         return StatusCode(500);
      }
   }
}
