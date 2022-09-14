﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using MotorolaExam.EntitiesDb.DAL.UnitOfWork;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotoTeamMember;
using MotorolaExam.Services.Services.Interfaces;
using System.Linq.Expressions;

namespace MotorolaExam.Services.Services.Controllers
{
   public class MotoTeamMemberService : IMotoTeamMemberService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;
      public MotoTeamMemberService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }

      public async Task<List<MotoTeamMemberReadDto>> GetAllAsync()
      {
         var allMotoTeamMembers = await _unitOfWork.MotoTeamMembers.GetAllAsync();
         return _mapper.Map<List<MotoTeamMemberReadDto>>(allMotoTeamMembers);
      }
      public async Task<MotoTeamMemberReadDto> GetSingleAsync(Expression<Func<MotoTeamMember, bool>> condition)
      {
         var motoTeamMember = await _unitOfWork.MotoTeamMembers.GetSingleAsync(condition);
         return _mapper.Map<MotoTeamMemberReadDto>(motoTeamMember);
      }

      public async Task<MotoTeamMemberReadDto> CreateNewAsync(MotoTeamMemberCreateDto motoTeamMemberCreateDto)
      {
         var newMotoTeamMember = _mapper.Map<MotoTeamMember>(motoTeamMemberCreateDto);
         await _unitOfWork.MotoTeamMembers.AddAsync(newMotoTeamMember);
         await _unitOfWork.CompleteUnitOfWorkAsync();
         return _mapper.Map<MotoTeamMemberReadDto>(newMotoTeamMember);
      }

      public async Task DeleteAsync(Expression<Func<MotoTeamMember, bool>> condition)
      {
         var motoTeamMemberToDelete = await _unitOfWork.MotoTeamMembers.GetSingleAsync(condition);
         if (motoTeamMemberToDelete is null)
            throw new ArgumentNullException($"Educational material not found");

         await _unitOfWork.MotoTeamMembers.DeleteAsync(motoTeamMemberToDelete);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }

      public async Task PutAsync(Expression<Func<MotoTeamMember, bool>> condition, MotoTeamMemberUpdateDto motoTeamMemberUpdateDto)
      {
         var motoTeamMemberToUpdate = await _unitOfWork.MotoTeamMembers.GetSingleAsync(condition);
         if (motoTeamMemberToUpdate is null)
            throw new ArgumentNullException($"Educational material not found");

         _mapper.Map(motoTeamMemberUpdateDto, motoTeamMemberToUpdate);

         await _unitOfWork.MotoTeamMembers.EditAsync(motoTeamMemberToUpdate);
      }

      public async Task PatchAsync(Expression<Func<MotoTeamMember, bool>> condition, JsonPatchDocument motoTeamMemberPatch)
      {
         var motoTeamMemberToUpdate = await _unitOfWork.MotoTeamMembers.GetSingleAsync(condition);
         if (motoTeamMemberToUpdate is null)
            throw new ArgumentNullException($"Educational material not found");

         motoTeamMemberPatch.ApplyTo(motoTeamMemberToUpdate);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }
   }
}