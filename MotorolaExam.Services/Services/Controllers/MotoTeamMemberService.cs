using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using MotorolaExam.EntitiesDb.DAL.UnitOfWork;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotorolaProject;
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
         if (motoTeamMember is null)
            throw new ArgumentNullException($"Motorola team member not found");

         return _mapper.Map<MotoTeamMemberReadDto>(motoTeamMember);
      }

      public async Task<MotoTeamMemberReadDto> CreateNewAsync(MotoTeamMemberCreateDto motoTeamMemberCreateDto)
      {
         var newMotoTeamMember = _mapper.Map<MotoTeamMember>(motoTeamMemberCreateDto);
         await _unitOfWork.MotoTeamMembers.AddAsync(newMotoTeamMember);
         return _mapper.Map<MotoTeamMemberReadDto>(newMotoTeamMember);
      }

      public async Task DeleteAsync(Expression<Func<MotoTeamMember, bool>> condition)
      {
         var motoTeamMemberToDelete = await _unitOfWork.MotoTeamMembers.GetSingleAsync(condition);
         if (motoTeamMemberToDelete is null)
            throw new ArgumentNullException($"Motorola team member not found");

         await _unitOfWork.MotoTeamMembers.DeleteAsync(motoTeamMemberToDelete);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }

      public async Task PutAsync(Expression<Func<MotoTeamMember, bool>> condition, MotoTeamMemberUpdateDto motoTeamMemberUpdateDto)
      {
         var motoTeamMemberToUpdate = await _unitOfWork.MotoTeamMembers.GetSingleAsync(condition);
         if (motoTeamMemberToUpdate is null)
            throw new ArgumentNullException($"Motorola team member not found");

         _mapper.Map(motoTeamMemberUpdateDto, motoTeamMemberToUpdate);

         await _unitOfWork.MotoTeamMembers.EditAsync(motoTeamMemberToUpdate);
      }

      public async Task PatchAsync(Expression<Func<MotoTeamMember, bool>> condition, JsonPatchDocument motoTeamMemberPatch)
      {
         var motoTeamMemberFromDb = await _unitOfWork.MotoTeamMembers.GetSingleAsync(condition);
         if (motoTeamMemberFromDb is null)
            throw new ArgumentNullException($"Motorola team member not found");

         var motorolaTeamMemberToPatch = _mapper.Map<MotoTeamMemberUpdateDto>(motoTeamMemberFromDb);

         motoTeamMemberPatch.ApplyTo(motorolaTeamMemberToPatch);

         _mapper.Map(motorolaTeamMemberToPatch, motoTeamMemberFromDb);

         await _unitOfWork.MotoTeamMembers.EditAsync(motoTeamMemberFromDb);
      }
   }
}
