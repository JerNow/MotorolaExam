using AutoMapper;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotorolaTeam;

namespace MotorolaExam.Services.Models.Profiles
{
   public class MotorolaTeamProfile : Profile
   {
      public MotorolaTeamProfile()
      {
         CreateMap<MotorolaTeam, MotorolaTeamReadDto>();
      }
   }
}
