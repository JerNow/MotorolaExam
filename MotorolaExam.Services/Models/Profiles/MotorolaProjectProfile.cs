using AutoMapper;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotorolaProject;

namespace MotorolaExam.Services.Models.Profiles
{
   public class MotorolaProjectProfile : Profile
   {
      public MotorolaProjectProfile()
      {
         CreateMap<MotorolaProject, MotorolaProjectReadDto>();
         CreateMap<MotorolaProjectCreateDto, MotorolaProject>();
         CreateMap<MotorolaProjectUpdateDto, MotorolaProject>();
      }
   }
}
