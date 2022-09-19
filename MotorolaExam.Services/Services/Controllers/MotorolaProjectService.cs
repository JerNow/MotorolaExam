using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using MotorolaExam.EntitiesDb.DAL.UnitOfWork;
using MotorolaExam.EntitiesDb.Models.Entities;
using MotorolaExam.Services.Models.DTOs.MotorolaProject;
using MotorolaExam.Services.Services.Interfaces;
using System.Linq.Expressions;

namespace MotorolaExam.Services.Services.Controllers
{
   public class MotorolaProjectService : IMotorolaProjectService
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IMapper _mapper;

      public MotorolaProjectService(IUnitOfWork unitOfWork, IMapper mapper)
      {
         _unitOfWork = unitOfWork;
         _mapper = mapper;
      }

      public async Task<List<MotorolaProjectReadDto>> GetAllAsync()
      {
         var allMotorolaProjects = await _unitOfWork.MotorolaProjects.GetAllMotorolaProjectsAsync();
         return _mapper.Map<List<MotorolaProjectReadDto>>(allMotorolaProjects);
      }
      public async Task<MotorolaProjectReadDto> GetSingleAsync(Expression<Func<MotorolaProject, bool>> condition)
      {
         var motorolaProject = await _unitOfWork.MotorolaProjects.GetSingleMotorolaProjectAsync(condition);
         return _mapper.Map<MotorolaProjectReadDto>(motorolaProject);
      }

      public async Task<MotorolaProjectReadDto> CreateNewAsync(MotorolaProjectCreateDto motorolaProjectCreateDto)
      {
         var newMotorolaProject = _mapper.Map<MotorolaProject>(motorolaProjectCreateDto);
         await _unitOfWork.MotorolaProjects.AddAsync(newMotorolaProject);
         return _mapper.Map<MotorolaProjectReadDto>(newMotorolaProject);
      }

      public async Task DeleteAsync(Expression<Func<MotorolaProject, bool>> condition)
      {
         var motorolaProjectToDelete = await _unitOfWork.MotorolaProjects.GetSingleAsync(condition);
         if (motorolaProjectToDelete is null)
            throw new ArgumentNullException($"Motorola project not found");

         await _unitOfWork.MotorolaProjects.DeleteAsync(motorolaProjectToDelete);
         await _unitOfWork.CompleteUnitOfWorkAsync();
      }

      public async Task PutAsync(Expression<Func<MotorolaProject, bool>> condition, MotorolaProjectUpdateDto motorolaProjectUpdateDto)
      {
         var motorolaProjectToUpdate = await _unitOfWork.MotorolaProjects.GetSingleAsync(condition);
         if (motorolaProjectToUpdate is null)
            throw new ArgumentNullException($"Motorola project not found");

         _mapper.Map(motorolaProjectUpdateDto, motorolaProjectToUpdate);

         await _unitOfWork.MotorolaProjects.EditAsync(motorolaProjectToUpdate);
      }

      public async Task PatchAsync(Expression<Func<MotorolaProject, bool>> condition, JsonPatchDocument motorolaProjectPatch)
      {
         var motorolaProjectFromDb = await _unitOfWork.MotorolaProjects.GetSingleAsync(condition);
         if (motorolaProjectFromDb is null)
            throw new ArgumentNullException($"Motorola project not found");

         var motorolaProjectToPatch = _mapper.Map<MotorolaProjectUpdateDto>(motorolaProjectFromDb);

         motorolaProjectPatch.ApplyTo(motorolaProjectToPatch);

         _mapper.Map(motorolaProjectToPatch, motorolaProjectFromDb);

         await _unitOfWork.MotorolaProjects.EditAsync(motorolaProjectFromDb);
      }
   }
}
