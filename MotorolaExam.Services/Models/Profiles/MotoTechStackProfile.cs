﻿using AutoMapper;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotoTechStack;

namespace MotorolaExam.Services.Models.Profiles
{
   public class MotoTechStackProfile : Profile
   {
      public MotoTechStackProfile()
      {
         CreateMap<MotoTechStack, MotoTechStackReadDto>();
      }
   }
}
