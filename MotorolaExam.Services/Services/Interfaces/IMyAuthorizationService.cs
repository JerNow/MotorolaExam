using Microsoft.AspNetCore.Identity;
using MotorolaExam.Services.Models;
using MotorolaExam.Services.Models.DTOs.Authorization;

namespace MotorolaExam.Services.Services.Interfaces
{
   public interface IMyAuthorizationService
   {
      Task<bool> AddAdminRole(UserRegistrationDto userRegistrationDto);
      Task<IdentityUser> DoesUserExistAsync(UserLoginRequestDto userLoginRequest);
      Task<bool> DoesUserExistAsync(UserRegistrationDto userRegistrationDto);
      Task<AuthorizationResult> LoginUser(UserLoginRequestDto userLoginRequest, IdentityUser user);
      Task<AuthorizationResult> RegisterNewUser(UserRegistrationDto userRegistrationDto);
   }
}
