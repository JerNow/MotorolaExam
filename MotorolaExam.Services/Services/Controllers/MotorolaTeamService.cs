using AutoMapper;
using MotorolaExam.EntitiesDb.DAL.UnitOfWork;
using MotorolaExam.Services.Services.Interfaces;

namespace MotorolaExam.Services.Services.Controllers
{
   public class MotorolaTeamService : IMotorolaTeamService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;

      public MotorolaTeamService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }

      public async Task<float> GetTeamAverageYearsAsync(int teamId)
      {
         var motorolaTeam = await _unitOfWork.MotorolaTeams.GetSingleWithIncludeAsync(mt => mt.Id == teamId, mt => mt.MotoTeamMembers);
         if (motorolaTeam is null)
            throw new ArgumentNullException($"Motorola team not found");
         float sumYears = 0;
         foreach(var motorolaTeamMember in motorolaTeam.MotoTeamMembers)
         {
            sumYears += motorolaTeamMember.YearsOfExpierience;
         }
         var result = sumYears / (float)motorolaTeam.MotoTeamMembers.Count();
         return result;
      }
   }
}
