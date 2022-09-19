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
         var registerResult = string.Empty;
         try
         {
            registerResult = await _authorizationService.RegisterNewUser(userRegistrationDto);
         } 
         catch(Exception e)
         {
            return StatusCode(500);
         }
         if (registerResult == string.Empty)
            return BadRequest("Creation process failed, try again with different credentials");
         return Ok(registerResult);
      }

      [HttpPost]
      [Route("Login")]
      public async Task<IActionResult> Login(UserLoginRequestDto userLoginRequest)
      {
         var userFromDb = await _authorizationService.DoesUserExistAsync(userLoginRequest);
         if (userFromDb == null)
            return BadRequest("Invalid creditentials"); //no user in Db found

         var result = await _authorizationService.LoginUser(userLoginRequest, userFromDb);
         if (result == string.Empty)
            return BadRequest("Invalid creditentials"); //password mismatch

         return Ok(result);
      }

      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
      [HttpPost]
      [Route("RegisterAdmin")]
      public async Task<IActionResult> RegisterAdmin(UserRegistrationDto userRegistrationDto)
      {
         var checkResult = await _authorizationService.DoesUserExistAsync(userRegistrationDto);
         if (checkResult == true)
            return BadRequest("User with that email already exist");
         var registerResult = string.Empty;
         try
         {
            registerResult = await _authorizationService.RegisterNewUser(userRegistrationDto);
         }
         catch (Exception e)
         {
            return StatusCode(500);
         }
         if (registerResult == string.Empty)
            return BadRequest("Creation process failed, try again with different credentials");
         var roleAdditionresult = false;
         try
         {
            roleAdditionresult = await _authorizationService.AddAdminRole(userRegistrationDto);
         } 
         catch (Exception e)
         {
            StatusCode(500);
         }
         if (roleAdditionresult)
            return Ok(registerResult);
         return StatusCode(500);
      }
   }
}
