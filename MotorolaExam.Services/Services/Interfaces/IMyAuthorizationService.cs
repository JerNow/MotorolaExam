using Microsoft.AspNetCore.Identity;
using MotorolaExam.Services.Models.DTOs.Authorization;

namespace MotorolaExam.Services.Services.Interfaces
{
   public interface IMyAuthorizationService
   {
      Task<bool> AddAdminRole(UserRegistrationDto userRegistrationDto);
      Task<IdentityUser> DoesUserExistAsync(UserLoginRequestDto userLoginRequest);
      Task<bool> DoesUserExistAsync(UserRegistrationDto userRegistrationDto);
      Task<string> LoginUser(UserLoginRequestDto userLoginRequest, IdentityUser user);
      Task<string> RegisterNewUser(UserRegistrationDto userRegistrationDto);
   }
}
