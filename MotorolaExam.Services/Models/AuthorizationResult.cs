namespace MotorolaExam.Services.Models
{
   public class AuthorizationResult
   {
      public bool Success { get; set; }
      public string Message { get; set; }

      public AuthorizationResult(bool success, string message)
      {
         Success = success;
         Message = message;
      }

      public override bool Equals(object? obj)
      {
         return obj is AuthorizationResult result &&
                Success == result.Success &&
                Message == result.Message;
      }

      public override int GetHashCode()
      {
         return HashCode.Combine(Success, Message);
      }

      public override string? ToString()
      {
         return "AuthorizationResult: " + Success.ToString() + ' ' + Message.ToString();
      }
   }
}
