namespace MotorolaExam.Services.Services.Interfaces
{
   public interface IMotorolaTeamService
   {
      Task<float> GetTeamAverageYearsAsync(int teamId);
   }
}
