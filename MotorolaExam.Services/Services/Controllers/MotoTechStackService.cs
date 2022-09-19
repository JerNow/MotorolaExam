using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using MotorolaExam.EntitiesDb.DAL.UnitOfWork;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotoTechStack;
using MotorolaExam.Services.Services.Interfaces;
using System.Linq.Expressions;

namespace MotorolaExam.Services.Services.Controllers
{
   public class MotoTechStackService : IMotoTechStackService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;
      public MotoTechStackService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }

      public async Task<List<MotoTechStackReadDto>> GetAllAsync()
      {
         var allMotoTechStacks = await _unitOfWork.MotoTechStacks.GetAllAsync();
         return _mapper.Map<List<MotoTechStackReadDto>>(allMotoTechStacks);
      }
      public async Task<MotoTechStackReadDto> GetSingleAsync(Expression<Func<MotoTechStack, bool>> condition)
      {
         var motoTechStack = await _unitOfWork.MotoTechStacks.GetSingleAsync(condition);
         if (motoTechStack is null)
            throw new ArgumentNullException($"Motorola technological stack not found");

         return _mapper.Map<MotoTechStackReadDto>(motoTechStack);
      }

      public async Task<MotoTechStackReadDto> CreateNewAsync(MotoTechStackCreateDto motoTechStackCreateDto)
      {
         var newMotoTechStack = _mapper.Map<MotoTechStack>(motoTechStackCreateDto);
         await _unitOfWork.MotoTechStacks.AddAsync(newMotoTechStack);
         return _mapper.Map<MotoTechStackReadDto>(newMotoTechStack);
      }

      public async Task PutAsync(Expression<Func<MotoTechStack, bool>> condition, MotoTechStackUpdateDto motoTechStackUpdateDto)
      {
         var motoTechStackToUpdate = await _unitOfWork.MotoTechStacks.GetSingleAsync(condition);
         if (motoTechStackToUpdate is null)
            throw new ArgumentNullException($"Motorola technological stack not found");

         _mapper.Map(motoTechStackUpdateDto, motoTechStackToUpdate);

         await _unitOfWork.MotoTechStacks.EditAsync(motoTechStackToUpdate);
      }

      public async Task PatchAsync(Expression<Func<MotoTechStack, bool>> condition, JsonPatchDocument motoTechStackPatch)
      {
         var motoTechStackFromDb = await _unitOfWork.MotoTechStacks.GetSingleAsync(condition);
         if (motoTechStackFromDb is null)
            throw new ArgumentNullException($"Motorola technological stack not found");

         var motoTechStackToPatch = _mapper.Map<MotoTechStackUpdateDto>(motoTechStackFromDb);

         motoTechStackPatch.ApplyTo(motoTechStackToPatch);

         _mapper.Map(motoTechStackToPatch, motoTechStackFromDb);

         await _unitOfWork.MotoTechStacks.EditAsync(motoTechStackFromDb);
      }
   }
}
