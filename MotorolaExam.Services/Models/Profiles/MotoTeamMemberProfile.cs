using AutoMapper;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotoTeamMember;

namespace MotorolaExam.Services.Models.Profiles
{
   internal class MotoTeamMemberProfile : Profile
   {
      public MotoTeamMemberProfile()
      {
         CreateMap<MotoTeamMember, MotoTeamMemberReadDto>();
         CreateMap<MotoTeamMemberCreateDto, MotoTeamMember>();
         CreateMap<MotoTeamMemberUpdateDto, MotoTeamMember>();
      }
   }
}
